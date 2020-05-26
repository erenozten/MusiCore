using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCore.ViewModels
{
    public class ValidTime: ValidationAttribute
    {
        public override bool IsValid(object arrivedTimeofDateTime)
        {
            DateTime newTimeOfDateTime;

            // Tryparseexact -> bool sonuç döner. Burada yapılan şu:
            // istediğimiz formatı D MMM YYYY olarak girebilmek için TryParseExact'ı kullandık.
            // TryParseExact, içinde bulunduğumuz IsValid metoduna gelen "Date" değerini,
            // arrivedDateOfDateTime parametresine atıyor. Aşağıda ise, arrivedDateOfDateTime (elimize geçen "Date" değeri anlamında),
            // değerinin valid bir değer olup olmadığını çözümlüyor ve valid ise return(true) yapmış oluyoruz.
            // bu noktada yine bu metodun bool değer döndüğüne dikkat edelim. Zaten bu metodun işi; girilen "Date" değerinin valid mi değil mi onun anlaşılmasını sağlamaktı.
            // Peki valid bir Date değeri nasıl olmalı? 
            // Öncelikle, elimize gelen Date değerinin (arrivedDateOfDateTime), istediğimiz formata uygun olması gerekir (DD MMM YYYY)
            // İkinci olarak, gelen Date değeri, günümüzden ileri bir tarihte olmalıdır (veya günümüze eşit).
            // Birinci durumu nasıl başardık, ona bakalım:
            // TryParseExact'ten gelen bool değeri "isvalid" değişkenine attık. Yani TryParseExact başarıyla sonuçlanmışsa, isvalid değeri True olarak dönmüş olacak.  Değilse False.
            // False dönerse zaten bu metod direk false dönecektir; arrivedDateOfDateTime değeri günümüzden ileri bir tarih olsa bile (bkz: return (isValid && newDateOfDateTime > DateTime.Now)
            // Birinci durum böylelikle halledildi.
            // İkinci durum ise zate: newDateOfDateTime > Datetime.Now olayıyla çözüldü.


            var isValid = DateTime.TryParseExact(Convert.ToString(arrivedTimeofDateTime),
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out newTimeOfDateTime);

            return (isValid);

            // formata dikkat: HH mm şeklinde.
        }

    }
}
