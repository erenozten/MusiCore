﻿using System;
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
        //public JsonResult CreateWithJson(int gigIdInActionResult, bool doIWannaGoInActionResult, string artistIdInActionResult) //// artistIdInActionResult'ı sildik. Çünkü zaten Include metodu ekledik aşağıdaki sorguya; yani oradan artistId'sine zaten ulaşabiliyoruz.
        public JsonResult Attend(int gigIdInActionResult, bool doIWannaGoInActionResult)
        {
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



        public JsonResult FollowOrUnfollow(int gigIdInJsonResult, string followedOrUnfollowedUserId, bool wannaFollowInJsonResult, bool wannaUnfollowInJsonResult, bool wannaUnfollow)
        {
            //var concert = _context.Concerts.FirstOrDefault(c => c.Id == gigIdInJsonResult);
            var concert = _context.Concerts.Where(c => c.Id == gigIdInJsonResult).Include(c=>c.Artist).Single();
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
           
            var exists = _context.Followings.Any(f =>
                f.FollowerId == currentUserId && f.FolloweeId == concert.ArtistId);

            if (!exists)
            {
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
            }

            if (exists)
            {
                // Takibi bırakmak istiyorsa:
                if (wannaUnfollowInJsonResult)
                {
                    try
                    {
                        var followingToDelete = _context.Followings
                            .Single(f => f.FollowerId == currentUserId && f.FolloweeId == concert.ArtistId);

                        _context.Followings.Remove(followingToDelete);
                        _context.SaveChanges();
                        return Json(new { resultOfUnfollowing = true, resultOfFollowing = false, followedOrUnfollowedArtistName = concert.Artist.Name });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        return Json(new { showToUser = "Bir şeyler ters gitti!" });
                    }
                }
                return Json(new { resultOfFollowing = false, showToUser = "Bu kişiyi zaten takip ediyorsunuz!" });
            }
            return Json(new { showToUser = "Bir şeyler ters gitti!" });
        }

    }
}