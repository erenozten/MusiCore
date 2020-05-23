using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MusiCore.Controllers
{
    public class TextsController : Controller
    {
        public IActionResult About()
        {
            // Proje ne işe yaramaktadır? Sorusunu cevaplayacak olan ActionResult
            return View();
        }

        public IActionResult Technologies()
        {
            // Projede kullanılan teknolojilerin, tekniklerin belirtilecek olduğu ActionResult.
            return View();
        }

        public IActionResult Logs()
        {
            // Projeye eklenen çıkarılan her şeyin log'landığı ActionResult.
            return View();
        }

        public IActionResult Bosch()
        {
            return View();
        }
    }
}