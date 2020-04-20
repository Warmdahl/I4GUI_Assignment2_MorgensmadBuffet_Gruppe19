using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Buffet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buffet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Buffet.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        //private readonly ILogger<HomeController> _logger;

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

        [Authorize("CanEnterKitchen")]
        public async Task<IActionResult> Kitchen()
        {
            var kitchen = new Kitchen();

            var guest = await _context.Guests.ToListAsync();

            kitchen.TotalAll = guest.Where(g => g.Date.Date == DateTime.Today).Count();
            kitchen.AdultsTotal = guest.Where(g => g.AgeStatus == "Adult" && g.Date.Date == DateTime.Today).Count();
            kitchen.ChildrenTotal = guest.Where(g => g.AgeStatus == "Child" && g.Date.Date == DateTime.Today).Count();
            kitchen.AdultsCheckedIn = guest.Where(g => g.Checked == true && g.AgeStatus == "Adult" && g.Date.Date == DateTime.Today).Count();
            kitchen.ChildrenCheckedIn = guest.Where(g => g.Checked == true && g.AgeStatus == "Child" && g.Date.Date == DateTime.Today).Count();
            kitchen.NotCheckedIn = guest.Where(g => g.Checked == false && g.Date.Date == DateTime.Today).Count();
            kitchen.AdultNotCheckedIn = guest.Where(g => g.Checked == false && g.AgeStatus == "Adult" && g.Date.Date == DateTime.Today).Count();
            kitchen.ChildrenNotCheckedIn = guest.Where(g => g.Checked == false && g.AgeStatus == "Child" && g.Date.Date == DateTime.Today).Count();

            return View(kitchen);
        }

        [Authorize("CanEnterReception")]
        public IActionResult Reception()
        {
            return View();
        }

        [Authorize("CanEnterRestaurant")]
        public IActionResult Restaurant()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
