using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCore.TextModels
{
    public class CampaignOfFixation
    {
        public CampaignOfFixation()
        {
            //DateCompleted = DateTime.Now; //tamamlandı olarak işaretlenmediyse: null olmalı DateCompleted
        }
        public int Id { get; set; }

        [Display(Name = "Türkçe")]
        public string TextTurkish { get; set; }

        [Display(Name = "İngilizce")]
        public string TextEnglish { get; set; }

        [Display(Name = "Tamamlandı mı?")]
        public bool IsDone { get; set; }

        // private set'i kaldırabilirsin diyo intellisense. Lakin EntityFramework kolonu düşürüyor, eğer setter'i silersen.
        // private set yaptık, çünkü dışarıdan şunun yapılmasını istemiyoruz: usedTechnology.DateCreatedAndCompleted = bla bla...  -> Bu yapılamamalı. Çünkü bu mantıksız bi işlem. Bu property zaten verinin oluştuğu anki tarihi tutuyor. Neden başka bir değer, bu değere set edilebilsin. O yüzden private set yaptık. Private yaptığımızdan ötürü ctor içinde Datetime.Now'a eşitleyebildik. Easy.
        public DateTime? DateCompleted { get; set; }

        public string GetMonth
        {
            get
            {
                if (IsDone)
                {
                    if (DateCompleted.HasValue)
                    {
                        return
                            "("
                            +
                            ((DateTime.Now.Month + DateTime.Now.Year * 12)
                             -
                             (DateCompleted.Value.Month + DateCompleted.Value.Year * 12))
                            .ToString()
                            +
                            " ay önce)";
                    }
                    else
                    {
                        return "Tamamlandı, fakat zamanı belirlenmedi";
                    }
                }
                else
                {
                    return " (Tamamlanmadı) ";
                }
            }
        }
    }
}