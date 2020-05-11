using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusiCore.Models;

namespace MusiCore.ViewModels
{
    public class ConcertFormViewModel
    {
        // property'leri string olarak oluşturduğumuza dikkat:

        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; } // db'deki tüm Genre'leri dropdownlist'e eklemek için kullanacağımız property
    }
}