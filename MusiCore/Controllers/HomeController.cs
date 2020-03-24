using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusiCore.Models;

namespace MusiCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MusiCoreDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, MusiCoreDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            Gig gig = new Gig();
            gig.Venue = "ss";
            _dbContext.Gigs.Add(gig);
            _dbContext.SaveChanges();
            ViewBag.Bag = gig.Venue;

            var list = _dbContext.Gigs.ToList();
            return View(list);
        }

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
