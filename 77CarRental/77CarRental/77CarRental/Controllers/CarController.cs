using _77CarRental.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _77CarRental.Controllers
{

    public class CarController : Controller
    {
        private readonly AppDbContext ctx;

        public CarController(AppDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Index()
        {
            var cars = ctx.Cars
                .ToList();
            return View(cars);
        }


        public IActionResult Detail (int? id)
        {
            if ( id == null)
            {
                return BadRequest();
            }
            var car = ctx.Cars
                .FirstOrDefault(c => c.CarId == id);

            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        private string uploadPhoto(Car car)
        {
            int carid = car.CarId;
            //upload photo
            string uploadsFolder = "wwwroot/images/";
            //change filename to a unique name picxx.filetype
            string uniqueFilename = "pic" + carid + Path.GetExtension(car.ImageFile.FileName);
            string filePath = uploadsFolder + uniqueFilename;
            //upload photo to folder
            car.ImageFile.CopyTo(new FileStream(filePath, FileMode.Create));
            return uniqueFilename;
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest(); //must use global exeception handling to redirect to custom error page
            }
            Car car = ctx.Cars.Find(id);//find the book with the given ID

            if (car == null)
            {
                return NotFound(); // must use global exeption handling to redirect user custom error page
            }


            return View(car);

        }

        [HttpPost]
        [Authorize(Roles ="Administrator")]
        public IActionResult Edit(Car car)

        {
            if (ModelState.IsValid)
            {
                //--------------- if a new photo was selected ------ //
                if (car.ImageFile != null)
                {
                    string newFileName = uploadPhoto(car);
                    car.ImagePath = newFileName;
                }
                // -------- update CoverPhotoName in database table ----------

                ctx.Cars.Update(car);
                ctx.SaveChanges();
                //redirect the user to the Details View and pass the book id of current book
                return Redirect("/Car/Detail/" + car.CarId);
            }
            return View(car);

        }

        [HttpGet] 
        // This indicates that this action is for rendering the page initially
        public IActionResult Create()
        {
            // Any initialization before showing the form can go here
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                ctx.Cars.Add(car);
                ctx.SaveChanges();

                //--------------- Upload file and update file name in table ------ //
                if (car.ImageFile != null)
                {
                    string newFileName = uploadPhoto(car);

                    // -------- update CoverPhotoName in database table ----------
                    car.ImagePath = newFileName;
                    ctx.Cars.Update(car);
                    ctx.SaveChanges();
                }
                // Redirect to the Index action to show the updated list of cars
                return RedirectToAction(nameof(Index));
            }

            // If ModelState is not valid, stay on the Create view and show validation errors
            return View(car);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var car = ctx.Cars.FirstOrDefault(c => c.CarId == id);
            if (car != null)
            {
                ctx.Cars.Remove(car);
                ctx.SaveChanges();
                TempData["SuccessMessage"] = "car successfully deleted.";
            }
            else
            {
                TempData["ErrorMessage"] = "car not found.";
            }

            return RedirectToAction(nameof(Index));
     
        }
        public IActionResult RentCar(int carId)
        {
            // Fetch the car from the database
            var car = ctx.Cars.FirstOrDefault(c => c.CarId == carId);
            if (car == null)
            {
                return NotFound();
            }

            // Update the car status to "Book"
            car.CarStatus = "Book";
            ctx.SaveChanges();

            return RedirectToAction("ViewCars", new { id = carId });
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult MakeAvailable(int carId)
        {
            // Fetch the car from the database
            var car = ctx.Cars.FirstOrDefault(c => c.CarId == carId);
            if (car == null)
            {
                return NotFound();
            }

            // Update the car status to "Available"
            car.CarStatus = "Available";
            ctx.SaveChanges();

            return RedirectToAction("ViewCars", new { id = carId });
        }

    }
}
    