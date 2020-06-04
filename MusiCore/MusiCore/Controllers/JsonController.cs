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
        //parametre int nullable olarak değiştirildi. Problem çıkabilir ileride. Attention!
        public JsonResult Attend(int? gigIdInActionResult, bool doIWannaGoInActionResult)
        {
            if (gigIdInActionResult == null)
            {
                return Json(new{message = "Hata! Konserin Id'si bulunamadı."});
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            var concert = _context.Concerts.Where(c => c.Id == gigIdInActionResult).Include(c => c.Artist).Single();

            var concertArtistId = concert.Artist.Id;

            var exists = _context.Attendances.Any(a => a.ConcertId == gigIdInActionResult && a.AttendeeId == currentUserId);

            //konsere gitmek istiyorsa:
            if (doIWannaGoInActionResult)
            {
                //konseri veren kişinin id'si, giriş yapmış olan kullanıcının id'sine eşit ise:
                if (concertArtistId == currentUserId)
                {
                    return Json(new { resultOfGoing = false, isItMyGig = true });
                }

                if (exists)
                {
                    return Json(new { resultOfGoing = false, showThisToUser = "Bu konsere zaten katılıyorsunuz!" });
                }

                try
                {
                    var newAttendance = new Attendance();
                    //newAttendance.ConcertId = gigIdInActionResult;
                    newAttendance.ConcertId = (int)gigIdInActionResult;
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

            // It's not always true goddamit.
            if (!doIWannaGoInActionResult) //expression always true diyor. Ama öyle değil. Test edildi.
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


        //parametre int nullable olarak değiştirildi. Problem çıkabilir ileride. Attention!
        //public JsonResult FollowOrUnfollow(int? gigIdInJsonResult, string followedOrUnfollowedUserId, bool wannaFollowInJsonResult, bool wannaUnfollowInJsonResult, bool wannaUnfollow)
        //parametre wannaFollow silindi.
        public JsonResult FollowOrUnfollow(int? gigIdInJsonResult, string followedOrUnfollowedUserId, bool wannaFollowInJsonResult, bool wannaUnfollowInJsonResult)
        {
            if (gigIdInJsonResult == null)
            {
                return Json(new { message = "Hata! Id değeri bulunamadı."});
            }
            //var concert = _context.Concerts.Where(c => c.Id == gigIdInJsonResult).Include(c=>c.Artist).Single();
            var concert = _context.Concerts.Include(c=>c.Artist).FirstOrDefault(c => c.Id == gigIdInJsonResult);
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
           
            var exists = _context.Followings.Any(f =>
                f.FollowerId == currentUserId && f.FolloweeId == concert.ArtistId);

            //kayıt db'de bulunamamış ise:
            if (!exists)
            {
                // kayıt db'de bulunamamış ise; kullanıcı wannaFollowInJsonResult'ı true olarak döndermiş olmalıdır, o halde yeni db'ye yeni kayıt eklenmelidir:
                if (wannaFollowInJsonResult)
                {
                    Following following = new Following()
                    {
                        FollowerId = currentUserId,
                        FolloweeId = concert.ArtistId
                    };
                    _context.Followings.Add(following);
                    _context.SaveChanges();

                    return Json(new { resultOfFollowing = true, resultOfUnfollowing = false, followedOrUnfollowedArtistName = concert.Artist.Name});
                }

                // kayıt db'de bulunamamış ise; wannaFollowInJsonResult'ı true olarak döndermiş olmalıdır, fakat öyle olmamış da wannaUnfollowInJsonResult true dönmüş ise ortada bir mantıksızlık var demektir. Özet: Db'de bir kayıt bulunamamışsa, bu kayıt unfollow da edilemez.. -->
                if (wannaUnfollowInJsonResult)
                {
                    //return edidlen wannaFollowInJsonResult ve wannaUnfollowInJsonResult değerleri sıkıntı çıkarabilir.
                    //açıklaması: kullanıcı unfollow etmek istiyordu; başarılı olsaydı; resultoffo.....
                    return Json(new { resultOfFollowing = wannaUnfollowInJsonResult, resultOfUnfollowing = wannaFollowInJsonResult, followedOrUnfollowedArtistName = concert.Artist.Name });
                }
            }

            if (exists)
            {
                // Takibi bırakmak istiyorsa:
                if (wannaUnfollowInJsonResult)
                {
                    var followingToDelete = _context.Followings
                        .FirstOrDefault(f => f.FollowerId == currentUserId && f.FolloweeId == concert.ArtistId);
                    try
                    {
                        _context.Followings.Remove(followingToDelete);
                        _context.SaveChanges();
                        return Json(new { resultOfUnfollowing = true, resultOfFollowing = false, followedOrUnfollowedArtistName = concert.Artist.Name });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        return Json(new { message = "Bir şeyler ters gitti!" });
                    }
                }
                return Json(new { resultOfFollowing = false, message = "Bu kişiyi zaten takip ediyorsunuz!" });
            }
            return Json(new { message = "Bir şeyler ters gitti!" });
        }

    }
}