using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCore.TextModels
{
    public class LogOfEverything
    {
        public int Id { get; set; }

        [Display(Name = "Türkçe")]
        public string TextTurkish { get; set; }

        [Display(Name = "İngilizce")]
        public string TextEnglish { get; set; }
    }
}
