using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Index()
        {
            return View();
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

            ApplicationUser asdf = new ApplicationUser();

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


            //foreach (var item in dbGenreList)
            //{
            //    listGenre.Add(new SelectListItem()
            //    {
            //        Text = item.Name,
            //        Value = item.Id.ToString()
            //    });
            //}
            //
            //////
            //Staff = new SelectList(staff, nameof(Person.Id), nameof(Person.Name), null, nameof(Person.Department));

            //ViewData["GenreBag"] = new SelectList(listGenre, "Value", "Text");

            return View(viewModel);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Create(ConcertFormViewModel viewModel)
        {

            //var artist = _context.Users.Single(u => u.Id = User.Identity.GetUserId);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            string userEmail = applicationUser?.Email; // will give the user's Email

            var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

            var concert = new Concert()
            {
                Artist = applicationUser,
                DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                Genre = genre,
                Venue = viewModel.Venue

            };

            return View();
        }
    }
}