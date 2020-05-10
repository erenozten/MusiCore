using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusiCore.Data;
using MusiCore.Models;
using MusiCore.ViewModels;

namespace MusiCore.Controllers
{
    public class GigController : Controller
    {
        private ApplicationDbContext _context;

        public GigController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            List<SelectListItem> listGenre = new List<SelectListItem>();

            var dbGenreList = _context.Genres.ToList();

            foreach (var item in _context.Genres)
            {
                listGenre.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            var viewModel = new GigFormViewModel
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
        public IActionResult Create(GigFormViewModel viewModel)
        {
            return View();
            return View();
        }
    }
}