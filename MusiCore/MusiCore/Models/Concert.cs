using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCore.Models
{
    public class Concert
    {
        public int Id { get; set; }
        public ApplicationUser Artist { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
    }
}