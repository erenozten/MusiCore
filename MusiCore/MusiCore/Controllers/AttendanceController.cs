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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AttendanceController : ControllerBase
    {
        private ApplicationDbContext _context;
        //private readonly UserManager<ApplicationUser> _userManager;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        //private ApplicationDbContext _context;
        //private readonly UserManager<ApplicationUser> _userManager;

        //public AttendanceController(UserManager<ApplicationUser> userManager, ApplicationDbContext context) //farklı iki constructor problem oluşturuyor. Tek contstructor ile userManager ve context alındı.
        //{
        //    _context = context;
        //    _userManager = userManager;
        //}

        [HttpPost]
        public async Task<ActionResult> Attend(int concertId)
        {
            // currentUser, concertId'ye sahip olan konsere katılıyor.
            // getUserId ile currentUser'in Id'si alınır.
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            // var attendance = new attendance
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

        // POST: api/TodoItems
        //[HttpPost]
        //public async Task<ActionResult> PostTodoItem(TodoItem todoItem)
        //{
        //    _context.TodoItems.Add(todoItem);
        //    await _context.SaveChangesAsync();

        //    //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        //    return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        //}
    }


}