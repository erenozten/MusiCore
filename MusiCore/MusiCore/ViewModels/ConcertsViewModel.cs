using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusiCore.Models;

namespace MusiCore.ViewModels
{
    public class ConcertsViewModel
    {
        public IEnumerable<Concert> UpcomingConcerts { get; set; }
        public bool ShowActions { get; set; }
    }
}
