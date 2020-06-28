using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusiCore.Data;
using MusiCore.Models;
using MusiCore.ViewModels;

namespace MusiCore.Controllers
{
    public class ConcertController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ConcertController(UserManager<ApplicationUser> userManager, ApplicationDbContext context) //farklı iki constructor problem oluşturuyor. Tek contstructor ile userManager ve context alındı.
        {
            _context = context;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            //üst kısım için --> _PartialViewForCreateTextTop
            //ViewData["ViewDataForClassName"] = "Teknoloji";
            //ViewData["ViewDataForControllerNameForGeriDonLink"] = "UsedTechnology";
            ViewData["ViewDataForFirstHeader"] = "Konserler";
            ViewData["ViewDataForSecondHeader"] = "Bir konsere katıl!";

            //alt kısım için --> _PartialViewForCreateTextBottom
            ViewData["ViewDataForCSSClassForEkleButton"] = "btn btn-green";
            ViewData["ViewDataForActionNameForGeriDonLink"] = "Index";
            ViewData["ViewDataForSaveButtonsValue"] = "Kaydet!";

            var concertsViewModel = new ConcertsViewModel()
            {
               UpcomingConcerts = _context.Concerts
                    .Include(c => c.Artist)
                    .Include(c => c.Genre)
                    .Where(c => c.DateTime > DateTime.Now),

               ShowActions = User.Identity.IsAuthenticated
        };
            return View(concertsViewModel);
        }

        [Authorize]
        public ActionResult Mine()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var concerts = _context.Concerts
                .Where(c => c.ArtistId == currentUserId && c.DateTime > DateTime.Now)
                .ToList();
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> listGenre = new List<SelectListItem>();

            foreach (var item in _context.Genres)
            {
                listGenre.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            var viewModel = new ConcertFormViewModel()
            {
                Genres =  _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConcertFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //model valid değilse, View'a dönüyoruz. Fakat bu durumda Genre için oluşturulmuş olan dropdownlist boş oluyor. Bunu tekrar populate etmemiz ve View'a yollamamız gerek:
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var genre = _context.Genres.First(g => g.Id == viewModel.Genre);

            var concert = new Concert()
            {
                ArtistId = userId,
                DateTime = viewModel.GetDateTime(),
                Genre = genre, //Genre = genre yerine GenreId = genreId olarak düzenleyelim.
                //GenreId = genre.Id,
                Venue = viewModel.Venue,
            };

            _context.Concerts.Add(concert);
            _context.SaveChanges();

            return RedirectToAction("Index", "Concert");
        }
    }
}



















