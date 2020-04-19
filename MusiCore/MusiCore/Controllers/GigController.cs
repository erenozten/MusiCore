using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusiCore.Data;

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
        public IActionResult Create()
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

            ViewData["GenreBag"] = new SelectList(listGenre, "Value", "Text");

            return View();
        }
    }
}