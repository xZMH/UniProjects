using _77CarRental.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace _77CarRental.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext ctx;

        public ReservationController(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IActionResult> Index()
        {
            var reservations = await ctx.Reservations
                                        .Include(c => c.Car)
                                        .Include(c => c.Customer)
                                        .ToListAsync();
            return View(reservations);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var reservation = await ctx.Reservations
                                       .Include(c => c.Car)
                                       .Include(c => c.Customer)
                                       .FirstOrDefaultAsync(c => c.ReservationId == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(ctx.Customers.Select(c => new
            {
                CustomerId = c.CustomerId,
                FullName = c.FirstName + " " + c.LastName
            }), "CustomerId", "FullName");

            // Concatenating Make and Model for the car selection
            ViewBag.CarId = new SelectList(ctx.Cars.Select(c => new
            {
                CarId = c.CarId,
                MakeModel = c.Make + " " + c.Model // This will be displayed in the dropdown
            }), "CarId", "MakeModel");

            return View();
        }

        [HttpPost]
       // [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                ctx.Reservations.Add(reservation);
                await ctx.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Repopulate ViewBag if there's a validation error
            ViewBag.CustomerId = new SelectList(ctx.Customers.Select(c => new
            {
                CustomerId = c.CustomerId,
                FullName = c.FirstName + " " + c.LastName
            }), "CustomerId", "FullName", reservation.CustomerId);

            ViewBag.CarId = new SelectList(ctx.Cars.Select(c => new
            {
                CarId = c.CarId,
                MakeModel = c.Make + " " + c.Model
            }), "CarId", "MakeModel", reservation.CarId);

            return View(reservation);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var reservation = ctx.Reservations.FirstOrDefault(c => c.ReservationId == id);
            if (reservation != null)
            {
                ctx.Reservations.Remove(reservation);
                ctx.SaveChanges();
                TempData["SuccessMessage"] = "Reservation successfully deleted.";
            }
            else
            {
                TempData["ErrorMessage"] = "Reservation not found.";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest(); //must use global exeception handling to redirect to custom error page
            }
            Reservation reservation = ctx.Reservations.Find(id);//find the book with the given ID

            if (reservation == null)
            {
                return NotFound(); // must use global exeption handling to redirect user custom error page
            }


            return View(reservation);

        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(Reservation reservation)

        {
            if (ModelState.IsValid)
            {

                ctx.Reservations.Update(reservation);
                ctx.SaveChanges();
                //redirect the user to the Details View and pass the book id of current book
                return Redirect("/Reservation/Detail/" + reservation.ReservationId);
            }
            return View(reservation);

        }

    }
}
