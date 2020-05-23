using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusiCore.Data;
using MusiCore.Models;

namespace MusiCore.Controllers
{
    public class HomeController : Controller
    {
        //Identity Entegrasyonu tamamlandı. Time to start to the Project!
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        //public HomeController(ILogger<HomeController> logger)
        //{

        //    _logger = logger;
        //}

        private UserManager<ApplicationUser> _userManager;

        //class constructor
        //public HomeController(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        //class constructor
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        //private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {
            var upcomingConcerts = _context.Concerts
                .Include(c => c.Artist)
                .Where(c => c.DateTime > DateTime.Now);

            // passedConcerts diye bir değişken oluşturup zamanı geçmiş olanları çağıralım. 

            return View(await upcomingConcerts.ToListAsync());

            //return View(await sarkicilar2.ToListAsync());

        }

        //public IActionResult Index()
        //{
        //    //ApplicationUser user = new ApplicationUser();
        //    //user.CustomTag = "svveris";

        //    //Concert concert = new Concert();
        //    //concert.Venue = "v";
        //    //_context.Concerts.Add(concert);
        //    //_context.SaveChanges();

        //    //_context.ApplicationUsers.Add(user);
        //    //_context.SaveChanges();

        //    //System.Security.Claims.ClaimsPrincipal currentUser = this.User;
        //    //var id = _userManager.GetUserId(User); // Get user id:
        //    return View();
        //}

        public IActionResult Privacy()
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
