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

            var upcomingsConcerts = _context.Concerts
                .Include(c=>c.Artist)
                .Include(c=>c.Genre)
                .Where(c => c.DateTime > DateTime.Now);

            return View(upcomingsConcerts);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> listGenre = new List<SelectListItem>();

            var dbGenreList = _context.Genres.ToList();


            //var artist = _context.Users.Single(u => u.Id = User.Identity.GetUserId);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            string userEmail = applicationUser?.Email; // will give the user's Email

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
                Genres = dbGenreList
            };

            //ViewData["GenreBag"] = new SelectList(listGenre, "Value", "Text");

            return View(viewModel);
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConcertFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            string userEmail = applicationUser?.Email; // will give the user's Email

            var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

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



















