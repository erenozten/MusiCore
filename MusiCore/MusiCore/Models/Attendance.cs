using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MusiCore.Models
{
    public class Attendance
    {
        [Key]
        [Column(Order = 1)]
        public int ConcertId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }

        public Concert Concert { get; set; }

        public ApplicationUser Attendee { get; set; }

    }
}
