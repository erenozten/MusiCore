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


        public JsonResult NewJsonPost(int dto2)
        {
           return Json(new { attendanceAdded = true});
           //return Json(new { attendanceAdded = true, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        //Iactionresult da oluyor
        //parametrelerde [FromBody] kullanılabilr.
        public JsonResult CreateWithJson(int gigIdInActionResult, bool doIWannaGoInActionResult, string artistIdInActionResult)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            var concert = _context.Concerts.Where(c=>c.Id == gigIdInActionResult).Include(c => c.Artist).Single();

            var exists = _context.Attendances.Any(a => a.ConcertId == gigIdInActionResult && a.AttendeeId == userId);

            //konsere gitmek istiyorsa:
            if (doIWannaGoInActionResult == true)
            {
                if (artistIdInActionResult == userId)
                {
                    return Json(new { resultOfGoing = false, showThisToUser = "Bu konseri siz veriyorsunuz!", isItMyGig = true });
                }

                if (exists)
                {
                    return Json(new { resultOfGoing = false, showThisToUser = "Bu konsere zaten katılıyorsunuz!", isItMyGig = true });
                }

                try
                {
                    var newAttendance = new Attendance();
                    newAttendance.ConcertId = gigIdInActionResult;
                    newAttendance.AttendeeId = userId;
                    _context.Attendances.Add(newAttendance);
                    _context.SaveChanges();
                    return Json(new
                    {
                        resultOfGoing = true, 
                        showThisToUser = "Konsere katılıyorsunuz", 
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
                //yukarıdaki return Json kısmına dikkat: success = false diye bi json verisi yolladık.
                //Buradaki success'in kesinlikle jQuery'nin Success veya Fail durumuyla ilgisi yok.
                //Bunu göstermek için success'i false yaptık. False olduğu halde Jquery post'unun Success kısmına düşüyor.
                //buradaki success sadece yollanan JSON objesinin verilerinden birisidir. Tıpkı diğerleri gibi: resultOfGoing, kafadanAtmaText.

                //kafadanAtmaText: Bu değişkeni jquery tarafında belirtmedik ama hata vermez. Sadece null olmuş olur.
                //yani jquery tarafındaki değişken sayısıyla buradaki parametre sayısı aynı olmak zorunda falan değil. 
                //Böyle bir zorunluluk olmadığını göstermek için bu değişkeni oluşturduk.
            }

            if (doIWannaGoInActionResult == false) //expression always true diyor. Ama öyle değil. Test edildi.
            {
                try
                {
                    var attend = _context.Attendances.Single(a => a.ConcertId == gigIdInActionResult && a.AttendeeId == userId);
                    _context.Attendances.Remove(attend);
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