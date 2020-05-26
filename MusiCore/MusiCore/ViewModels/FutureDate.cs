using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MusiCore.ViewModels
{
    public class ValidDate: ValidationAttribute  // ValidationAttribute'den kalıtım almamız gerekiyor.
    {
        public override bool IsValid(object arrivedDateOfDateTime) // IsValid metodunu override ediyoruz
        {
            DateTime newDateOfDateTime;

            // Tryparseexact -> bool sonuç döner. Burada yapılan şu:
            // istediğimiz formatı D MMM YYYY olarak girebilmek için TryParseExact'ı kullandık.
            // TryParseExact, arrivedDateOfDateTime değerini, yani metoda gelen değeri string'e çevirmeye çalışıyor.
            // Çevirebilmişse true dönüyor, çevirememişse false.
            // Şayet true dönmüşse, dönen sonucu newDateOfDateTime'a atıyor.
            // bu noktada yine bu metodun bool değer döndüğüne dikkat edelim. Zaten bu metodun işi; girilen "Date" değerinin valid mi değil mi onun anlaşılmasını sağlamaktı.
            // Peki valid bir Date değeri nasıl olmalı? 
            // Öncelikle, elimize gelen Date değerinin (arrivedDateOfDateTime), istediğimiz formata uygun olması gerekir (D MMM YYYY)
            // İkinci olarak, gelen Date değeri, günümüzden ileri bir tarihte olmalıdır (veya günümüze eşit).
            // Birinci durumu nasıl başardık, ona bakalım:
            // TryParseExact'ten gelen bool değeri "isvalid" değişkenine attık. Yani TryParseExact başarıyla sonuçlanmışsa, isvalid değeri True olarak dönmüş olacak.  Değilse False.
            // False dönerse zaten bu metod direk false dönecektir; arrivedDateOfDateTime değeri günümüzden ileri bir tarih olsa bile (bkz: return (isValid && newDateOfDateTime > DateTime.Now)
            // Birinci durum böylelikle halledildi.
            // İkinci durum ise zate: newDateOfDateTime > Datetime.Now olayıyla çözüldü.


            var isValid = DateTime.TryParseExact(Convert.ToString(arrivedDateOfDateTime),
                "d MMM yyyy", 
                CultureInfo.CurrentCulture, 
                DateTimeStyles.None,
                out newDateOfDateTime);

            return (isValid && newDateOfDateTime > DateTime.Now);
            // Dikkat!
            // Formatı belirtirken çok dikkatli olunmalı, sıkıntı çıkabiliyor.
            // örneğin şunlar sıkıntı çıkarıyor:
            // "D MMM yyyy" FALSE  (1 MAY 2055 değeri için) --> Sayıları küçük harfle belirtmek gerekiyor (gün ve yıl yani)
            // "d MMM YYYY" FALSE  (1 MAY 2055 değeri için)
            // "D MMm yyyy" FALSE  (1 MAY 2055 değeri için)
            // "d mmm yyyy" FALSE  (1 may 2055 değeri için) --> mmm küçük harfle belirttiğimiz halde ve "may" değerini verdiğimiz halde false dönüyor.
            
            // "MMM" diye belirttiğimizde, ister büyük ister küçük harf verelim, true dönüyor. Görünene göre; girilen string'i toUpper gibi bir metotla büyük harfe çeviriyor ve bu yüzden MMM true dönüyor.
            // Sonuç: sayılar küçük harfle, string (yani ay değeri) büyük harfle gösterilmeli. Şöyle:
            
            // "d MMM yyyy" TRUE
        }
    }
}
