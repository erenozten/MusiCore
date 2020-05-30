using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusiCore.Data;
using MusiCore.Models;

namespace MusiCore.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AttendanceController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        //actionresult'ın içine [FromBody] yazınca çalışmadı. Halbuki .net core öncesinde çalışıyordu.
        public async Task<ActionResult> Attend(int concertId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.ConcertId == concertId))
            {
                return BadRequest("Zaten katılıyorsunuz!");
            }
            Attendance attendance = new Attendance();

            // attendance.userId = currentUserId
            // attendance.ConcertId = concertId
            attendance.ConcertId = concertId;
            attendance.AttendeeId = userId;

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            ////return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            //return CreatedAtAction(concertId);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Concert> Get()
        {
            return _context.Concerts.ToList();
        }
    }


}