using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MusiCore.Controllers
{
    public class TextsController : Controller
    {
        public IActionResult About()
        {
            // Proje ne işe yaramaktadır? Sorusunu cevaplayacak olan ActionResult
            return View();
        }

        public IActionResult Technologies()
        {
            // Projede kullanılan teknolojilerin, tekniklerin belirtilecek olduğu ActionResult.

            // Proje .NET CORE 3.1 ile oluşturuldu.
            // Entity Framework kullanıldı.
            // Bootstrap kullanıldı.
            // Code-First Yaklaşımı kullanıldı.
            // Migration'lar kullanıldı.
            // Data Validation (Client Side Validation)
            // ASP.NET Identity (Sign Up, Login, Log out, Change Password etc.) 

            // Security Issues
            // Artistic UI
            return View();
        }

        public IActionResult Approaches()
        {
            // Projede benimsenen yaklaşımlarla ilgili kısa notların yazıldığı ActionResult.

            // Migration'lar küçük parçalar halinde oluşturuldu. Dolayısıyla veritabanı problemlerinin yaşanma olasılığı azaltıldı.
            // Proje bir müzik projesi olduğu için, yani gençlere hitap edeceği için tasarımda canlı renklere yer verildi.

            return View();
        }

        public IActionResult Logs()
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
            return View();
        }

        public IActionResult WillBeAdded()
        {
            // TextsController'da bulunan tüm actionresultlar için bir tablo oluşturalım, görev yapıldıysa true yapalım property'sini, değilse false.
            // Yapılmış olan görevler yeşil, yapılmamışlar kırmızı renk ile gösterilsin.
            // Buton ile bu görevleri "yapıldı" diye işaretleyebilelim. Ajax post yapılabilir bu noktada.
            // Görevlerin Türkçe ve İngilizce diye property'leri olsun. İngilizceye çevirdiklerimizi ingilizce property'sinde tutacağız.
            // Change Password
            // Add a gig
            // My Upcoming Gigs
            // Edit a gig
            // Remove a gig
            // View All Upcoming Gigs
            // Search Implementation
        
    }
}