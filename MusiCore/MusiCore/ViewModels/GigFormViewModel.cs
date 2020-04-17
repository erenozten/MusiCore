using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCore.ViewModels
{
    public class GigFormViewModel
    {
        // property'leri string olarak oluşturduğumuza dikkat:

        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
