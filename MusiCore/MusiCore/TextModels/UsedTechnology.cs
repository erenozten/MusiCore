using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCore.TextModels
{
    public class UsedTechnology
    {
        public UsedTechnology()
        {
            DateCreatedAndCompleted = DateTime.Now;
        }
        public int Id { get; set; }

        [Display(Name = "Türkçe")]
        public string TextTurkish { get; set; }

        [Display(Name = "İngilizce")]
        public string TextEnglish { get; set; }

        // private set'i kaldırabilirsin diyo intellisense. Lakin EntityFramework kolonu düşürüyor, eğer setter'i silersen.
        // private set yaptık, çünkü dışarıdan şunun yapılmasını istemiyoruz: usedTechnology.DateCreatedAndCompleted = bla bla...  -> Bu yapılamamalı. Çünkü bu mantıksız bi işlem. Bu property zaten verinin oluştuğu anki tarihi tutuyor. Neden başka bir değer, bu değere set edilebilsin. O yüzden private set yaptık. Private yaptığımızdan ötürü ctor içinde Datetime.Now'a eşitleyebildik. Easy.
        public DateTime DateCreatedAndCompleted { get; private set; } 
    }
}
