﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MusiCore.Models;

namespace MusiCore.ViewModels
{
    public class ConcertFormViewModel
    {
        // property'leri string olarak oluşturduğumuza dikkat:

        [Required]
        public string Venue { get; set; }
        
        public string Date { get; set; }
        
        public string Time { get; set; }
        
        [Required]
        public byte Genre { get; set; }
        
        //[Required]
        public IEnumerable<Genre> Genres { get; set; } // db'deki tüm Genre'leri dropdownlist'e eklemek için kullanacağımız property

        //public DateTime DateTime
        //{
        //    get { return DateTime.Parse(string.Format("{0} {1}", Date, Time)); }
        //}

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}