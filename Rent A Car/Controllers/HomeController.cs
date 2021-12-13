using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rent_A_Car.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Rent_A_Car.Models;
using Microsoft.EntityFrameworkCore;

namespace Rent_A_Car.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
     

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
          public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Overons()
        {
            return View();
        }
        public async Task<IActionResult> OverzichtMedewerker(string id)
        {
            var applicationDbContext = _context.RegisterViewModel.Include(v => v.ApplicationUser);


            return View(await applicationDbContext.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
