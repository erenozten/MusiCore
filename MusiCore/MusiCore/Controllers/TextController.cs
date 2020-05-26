using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MusiCore.Controllers
{
    public class TextController : Controller
    {
        public IActionResult AboutProject()
        {
            // Proje ne işe yaramaktadır? Sorusunu cevaplayacak olan ActionResult
            return View();
        }

        public IActionResult UsedTechnology()
        {
            // Projede kullanılan teknolojilerin, tekniklerin belirtilecek olduğu ActionResult.

            // Proje .NET CORE 3.1 ile oluşturuldu //db'ye eklendi
            // Entity Framework kullanıldı //db'ye eklendi
            // Code-First Yaklaşımı kullanıldı //db'ye eklendi
            // Migration'lar kullanıldı //db'ye eklendi
            // Client Side Validation entegrasyonu yapıldı //db'ye eklendi
            // ASP.NET Identity entegrasyonu yapıldı (Kaydol, Giriş Yap, Çıkış Yap, Şifre Değiştir) //db'ye eklendi
            // Partial View'lar kullanıldı //db'ye eklendi
            // Bootstrap kullanıldı //db'ye eklendi
                
            return View();
        }

        public IActionResult UsedApproach()
        {
            // Projede benimsenen yaklaşımlarla ilgili kısa notların yazıldığı ActionResult.

            // Migration'lar küçük parçalar halinde oluşturuldu. Dolayısıyla veritabanı problemleri yaşama olasılığı azaltıldı //db'ye eklendi
            // Proje bir müzik projesi olduğu için, yani gençlere hitap edeceği için tasarımda canlı renklere yer verildi //db'ye eklendi
            // Artistik tasarım uygulanmaya çalışıldı //db'ye eklendi

            return View();
        }

        public IActionResult LogOfEverything()
        {
            // Projeye eklenen çıkarılan her şeyin log'landığı ActionResult.

            // Proje başlatıldı. Roket kalkışa hazırlanıyor.
            // Proje GitHub'a eklendi.
            // ConnectionString yazıldı.
            // Entity Framework kuruldu.
            // Migration'lar aktive edildi.
            // ASP.NET Identity entegrasyonu sağlandı.
            // Concert class'ı oluşturuldu.
            // Genre class'ı oluşturuldu.
            // DbContext oluşturuldu.
            // ApplicationUser, Concert, Genre arasındaki ilişkiler kuruldu.
            // Her bir class'ta navigation property'ler oluşturuldu.
            // Her Concert'in bir Genre'si olmalı. Dolayısıyla Concert'in GenreId ismindeki Foreign Key'i Required olarak belirlendi. [Required] data annotation'ı kullanıldı. İleride Fluent Api de kullanılacak bu gibi işlemler için.
            // Genre tablosuna örnek müzik türü isimleri eklenerek (pop, rock, metal vb.) tablo populate edildi.
            // ConcertController eklendi.
            // Yeni Concert oluşturma sayfası eklendi.
            // Navbar'daki linkler düzenlendi, yeni linkler eklendi (Add a Concert bunlardan biri).
            // Bazı bootstrap class'ları override edildi. Override edilen class'lar Site.cs dosyasına eklendi. Sitedeki tüm style'lar şu an Site.cs dosyasında bulunuyor.
            // Concert class'ının DateTime property'si var. Fakat biz kullanıcıdan Date ve Time değerlerini ayrı ayrı alacağız. Date, yani Tarih değeri, örneğin 3 ocak 2021 değeri alınacak, time property'sinde ise saat değeri alınacak, örneğin 14:00. Bunu yapabilmek için ConcertViewModel oluşturuldu. Bu Viewmodel, Concert class'ının tüm değerlerine sahip, bunun yanında Date ve Time property'lerine sahip.
            // ConcertViewModel'den gelen Date ve Time değerleri, Concert'in Datetime'sine parse ediliyor. Bu işlem gerçekleştirildi.
            // Concert oluşturma sayfasında, genre seçimi için, tüm genre'lerin listelendiği bir dropdownlist oluşturuldu.
            // Bootstrap Button'larının default style'ları, siteyle uyumlu olacak şekilde override edildi.
            // Sisteme giriş yapmamış olan üyeler bazı ActionResult'lere ulaşamamalı. Bu yüzden bunlara [Authorize] attribute'ları eklendi.
            // Create [HttpPost] ActionResult'ı oluşturuldu ve ilk Concert kaydı veritabanına eklenmiş oldu. Good job bruh.
            // Create sayfası için client side validation oluşturuldu. Bunun için jQueryVal kullanıldı.
            // Loglama, kullanılan teknolojiler vb için birer tablo oluşturuldu. Bu bilgiler veritabanında tutulacak.
            // Partial view'lar ekleniyor.
            // Tasarım düzenleniyor. Bol bol CSS, HTML Chore...
            return View();
        }

        public IActionResult CampaignOfAddingNewModule()
        {
            // TextController'da bulunan tüm actionresultlar için bir tablo oluşturalım, görev yapıldıysa true yapalım property'sini, değilse false. //db'ye eklendi
            // Yapılmış olan görevler yeşil, yapılmamışlar kırmızı renk ile gösterilsin //db'ye eklendi
            // Buton ile bu görevleri "yapıldı" diye işaretleyebilelim. //db'ye eklendi
            // Görevleri "yapıldı, yapılmadı" olarak işaretleyebilme olayı Ajax post yapılabilir.
            // Görevlerin Türkçe ve İngilizce diye property'leri olsun. İngilizceye çevirdiklerimizi ingilizce property'sinde tutacağız.
            // Change Password
            // Sisteme konserler eklensin // db'ye eklendi
            // My Upcoming Gigs
            // Edit a gig
            // Remove a gig
            // View All Upcoming Gigs
            // Search Implementation
            // Paging Implementation
            // View gig Details
            // Add a Gig to Calendar
            // Remove a Gig from Calendar
            // View Gigs I'm Attending
            // Follow an Artist
            // Unfollow an Artist
            // Who I'm Following
            // Gig Feed
            // CSS style ları
            // Genre için CRUD işlemleri yapılmak üzere admin paneli oluşturulmalı
            // Security Issues (XSS falan, bunları ekleyelim)

            return View();
        }

        public IActionResult CampaignOfFixation()
        {
            // Index sayfalarında tablo çok genişleyebiliyor property'lerin uzunluğuna göre. Bunlar düzenlenmeli. Trim metotları kullanılmalı.
            return View();
        }
    }
}