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

            // Proje .NET CORE 3.1 ile oluşturuldu.
            // Entity Framework kullanıldı.
            // Bootstrap kullanıldı.
            // Code-First Yaklaşımı kullanıldı.
            // Migration'lar kullanıldı.
            // Data Validation (Client Side Validation)
            // ASP.NET Identity (Sign Up, Login, Log out, Change Password etc.) 

            // Security Issues
            // Artistic UI
            return View();
        }

        public IActionResult Approaches()
        {
            // Projede benimsenen yaklaşımlarla ilgili kısa notların yazıldığı ActionResult.

            // Migration'lar küçük parçalar halinde oluşturuldu. Dolayısıyla veritabanı problemlerinin yaşanma olasılığı azaltıldı.
            // Proje bir müzik projesi olduğu için, yani gençlere hitap edeceği için tasarımda canlı renklere yer verildi.

            return View();
        }

    }
}