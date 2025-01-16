using _77CarRental.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _77CarRental.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext ctx;
        public CustomerController(AppDbContext ctx) 
        {
            this.ctx = ctx;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            // Assuming you want to list all customers on the index page
            var customers = ctx.Customers.ToList();
            return View(customers);
        }


       
 [HttpGet] // This indicates that this action is for rendering the page initially
        public IActionResult Create()
        {
            // Any initialization before showing the form can go here
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                ctx.Customers.Add(customer);
                ctx.SaveChanges();

                // Redirect to the Index action to show the updated list of customers
                return RedirectToAction(nameof(Index));
            }

            // If ModelState is not valid, stay on the Create view and show validation errors
            return View(customer);
        }

        // Assuming you have a Details action to view a customer
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var customer = ctx.Customers
                .FirstOrDefault(c => c.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = ctx.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                ctx.Customers.Remove(customer);
                ctx.SaveChanges();
                TempData["SuccessMessage"] = "Customer successfully deleted.";
            }
            else
            {
                TempData["ErrorMessage"] = "Customer not found.";
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
            Customer customer = ctx.Customers.Find(id);//find the book with the given ID

            if (customer == null)
            {
                return NotFound(); // must use global exeption handling to redirect user custom error page
            }


            return View(customer);

        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(Customer customer)

        {
            if (ModelState.IsValid)
            {

                ctx.Customers.Update(customer);
                ctx.SaveChanges();
                //redirect the user to the Details View and pass the book id of current book
                return Redirect("/Customer/Detail/" + customer.CustomerId);
            }
            return View(customer);

        }

    }
}

    
