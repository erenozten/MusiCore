using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusiCore.Data;
using MusiCore.Models;

namespace MusiCore.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDbContext _context;
        //public TestController(ApplicationDbContext context)
        //{
        //    context = _context;
        //}

        public IActionResult Index()
        {


                ApplicationUser appUser = new ApplicationUser();
                appUser.CustomTag = "asd";
                _context.ApplicationUsers.Add(appUser);
                _context.SaveChanges();
            return View();
        }
    }
}