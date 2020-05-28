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
        //private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        //private UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var upcomingConcerts = _context.Concerts
                .Include(c => c.Artist)
                .Where(c => c.DateTime > DateTime.Now);

            // passedConcerts diye bir değişken oluşturup zamanı geçmiş olanları da çağıralım. 

            return View(await upcomingConcerts.ToListAsync());

            //return View(await sarkicilar2.ToListAsync());

        }

        public async Task<IActionResult> About()
        {
            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Teknoloji";
            //ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedTechnology";
            ViewData["ViewDataForFirstHeader"] = "Hakkında";
            ViewData["ViewDataForSecondHeader"] = "Proje Ne İşe Yarıyor?";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Kaydet!";

            //return View(); yazarsak asyncronous programming olmuyor. Async ve await beraber kullanılmalı.
            return await Task.Run(() => View());

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
