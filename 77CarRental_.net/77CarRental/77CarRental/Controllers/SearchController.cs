using _77CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _77CarRental.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext ctx;
        public SearchController(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        //public IActionResult SearchByMake(int? CarMake)
        //{
        //    if(CarMake == null || CarMake == 0)
        //    {
             
              
        //        return View();

        //    }

        //    var cars = ctx.Cars
        //        .Where(b => b.Make.Contains(b.Make))
        //        .Include(b => b.Make)
        //        .ToList();
        //    return PartialView("_PartialSearchResult", cars);

        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
