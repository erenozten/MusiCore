using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusiCore.Data;
using MusiCore.Models;

namespace MusiCore.Controllers
{
    public class JsonController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public JsonController(UserManager<ApplicationUser> userManager, ApplicationDbContext context) //farklı iki constructor problem oluşturuyor. Tek contstructor ile userManager ve context alındı.
        {
            _context = context;
            _userManager = userManager;
        }
        
        [HttpPost]
        //Iactionresult da oluyor
        //parametrelerde [FromBody] kullanılabilr.
        //public JsonResult CreateWithJson(int gigIdInActionResult, bool doIWannaGoInActionResult, string artistIdInActionResult) //// artistIdInActionResult'ı sildik. Çünkü zaten Include metodu ekledik aşağıdaki sorguya; yani oradan artistId'sine zaten ulaşabiliyoruz.
        public JsonResult CreateWithJson(int gigIdInActionResult, bool doIWannaGoInActionResult)

        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            var concert = _context.Concerts.Where(c=>c.Id == gigIdInActionResult).Include(c => c.Artist).Single();

            var concertArtistId = concert.Artist.Id;

            var exists = _context.Attendances.Any(a => a.ConcertId == gigIdInActionResult && a.AttendeeId == currentUserId);

            //konsere gitmek istiyorsa:
            if (doIWannaGoInActionResult == true)
            {
                //konseri veren kişinin id'si, giriş yapmış olan kullanıcının id'sine eşit ise:
                if (concertArtistId == currentUserId)
                {
                    return Json(new { resultOfGoing = false, isItMyGig = true });
                }

                if (exists)
                {
                    return Json(new { resultOfGoing = false, showThisToUser = "Bu konsere zaten katılıyorsunuz!"});
                }

                try
                {
                    var newAttendance = new Attendance();
                    newAttendance.ConcertId = gigIdInActionResult;
                    newAttendance.AttendeeId = currentUserId;
                    _context.Attendances.Add(newAttendance);
                    _context.SaveChanges();
                    return Json(new
                    {
                        resultOfGoing = true, 
                        concertArtistName = concert.Artist.Name,
                        concertVenue = concert.Venue
                    });

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return Json(new { resultOfGoing = true, kafadanAtmaText = "hata", success = false });
                    throw;
                }
            }

            if (doIWannaGoInActionResult == false) //expression always true diyor. Ama öyle değil. Test edildi.
            {
                try
                {
                    var attendance = _context.Attendances.Single(a => a.ConcertId == gigIdInActionResult && a.AttendeeId == currentUserId);
                    _context.Attendances.Remove(attendance);
                    _context.SaveChanges();
                    return Json(new { resultOfGoing = false, kafadanAtmaText = "İkinci işe yaramayan Text." });

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return Json(new { resultOfGoing = false, kafadanAtmaText = "Hata" });
                    throw;
                }
            }
            return Json(new { resultOfGoing = false, kafadanAtmaText = "İkinci işe yaramayan Text." });
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public JsonResult NewJsonPost(int dto2)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

        //    /*db'ye fazladan sorgu atmamak için, db'ye bir kez bağlanıp 
        //    buradan gelen değeri UserId değişkenine attık.
        //    */

        //    var theAttendance = _context.Attendances.Where(a => a.AttendeeId == userId && a.GigId == dto2).SingleOrDefault();
        //    //var sayi = theAttendance.Count();

        //    //var exists = _context.Attendances. //exists: bool değişken
        //    //    Any(a => a.AttendeeId == userId
        //    //    &&
        //    //    a.GigId == dto.GigId);

        //    /*Yeni bir Attendance eklenebilmesi için 
        //    elimizdeki iki Primary Key kombinasyonunun (AttendeeId, GigId) 
        //    özel olması gerekir.
        //    */

        //    if (theAttendance != null)
        //    {
        //        //return BadRequest("Bu attendance'a zaten katılıyorsunuz!");
        //        _context.Attendances.Remove(theAttendance);
        //        _context.SaveChanges();
        //        return Json(new { attendanceDeleted = true, JsonRequestBehavior.AllowGet });
        //    }
        //    var attendance = new Attendance
        //    {
        //        GigId = dto2,
        //        AttendeeId = userId
        //    };
        //    _context.Attendances.Add(attendance);
        //    _context.SaveChanges();
        //    return Json(new { attendanceAdded = true, JsonRequestBehavior.AllowGet });
        //}


    }
}