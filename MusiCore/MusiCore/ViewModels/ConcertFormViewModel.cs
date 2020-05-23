using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MusiCore.Models;

namespace MusiCore.ViewModels
{
    public class ConcertFormViewModel
    {
        // property'leri string olarak oluşturduğumuza dikkat:


        //[MinLength(2, ErrorMessage = "Bu alan en az 2 karakterden oluşmalıdı.")]
        //[StringLength(3000, ErrorMessage = "Bu alan en fazla 100 karakterden oluşmalıdı.")]
        //[DisplayFormat(NullDisplayText = "Veri yok")]
        //[Display(Name="Yer")]


        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Display(Name = "Yer", Prompt = "Kadıköy")]
        [MinLength(2, ErrorMessage = "Bu alan en az 2 karakterden oluşmalıdı.")]
        [StringLength(3000, ErrorMessage = "Bu alan en fazla 100 karakterden oluşmalıdı.")]
        public string Venue { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [FutureDate]
        [Display(Name = "Tarih", Prompt = "13 Jan 2023")]

        public string Date { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [FutureTime]
        [Display(Name = "Saat", Prompt = "13 Jan 2023")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Display(Name = "Tür")]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; } // db'deki tüm Genre'leri dropdownlist'e eklemek için kullanacağımız property

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}