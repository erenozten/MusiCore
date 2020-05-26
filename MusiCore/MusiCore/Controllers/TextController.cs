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

        public IActionResult UsedTechnology() //ok
        {
            // Projede kullanılan teknolojilerin, tekniklerin belirtilecek olduğu ActionResult.

            // Proje .NET CORE 3.1 ile oluşturuldu //db'ye eklendi
            // Entity Framework kullanıldı //db'ye eklendi
            // Migration'lar kullanıldı //db'ye eklendi
            // Client Side Validation entegrasyonu yapıldı //db'ye eklendi
            // ASP.NET Identity entegrasyonu yapıldı (Kaydol, Giriş Yap, Çıkış Yap, Şifre Değiştir) //db'ye eklendi
            // Partial View'lar kullanıldı //db'ye eklendi
            // Bootstrap kullanıldı //db'ye eklendi

            // BURAYA KADAR OK!

            // Bundling yapısı kullanıldı
            // Data Annotations

            return View();
        }

        public IActionResult UsedApproach() //ok
        {
            // Projede benimsenen yaklaşımlarla ilgili kısa notların yazıldığı ActionResult.

            // Migration'lar küçük parçalar halinde oluşturuldu. Dolayısıyla veritabanı problemleri yaşama olasılığı azaltıldı //db'ye eklendi
            // Proje bir müzik projesi olduğu için, yani gençlere hitap edeceği için tasarımda canlı renklere yer verildi //db'ye eklendi
            // Artistik tasarım uygulanmaya çalışıldı //db'ye eklendi
            // EF Code-First Yaklaşımı kullanıldı //db'ye eklendi

            // BURAYA KADAR OK!

            // Proje .NET Core'da geliştirildiği için XSS saldırılarını bertaraf edebiliyor; JavaScript inputlarını default olarak reddediyor.
            // Güvenlik: CSRF saldırıları Anti-forgery Token yapısı sayesinde kolaylıkla bertaraf edilebiliyor. (@Html.AntiForgeryToken ve [ValidateAntiForgeryToken])

            //
            return View();
        }

        public IActionResult LogOfEverything() //ok
        {
            // Projeye eklenen çıkarılan her şeyin log'landığı ActionResult.

            // Proje başlatıldı. Roket kalkışa hazırlanıyor //db'ye eklendi
            // Proje GitHub'a eklendi //db'ye eklendi
            // ConnectionString oluşturuldu //db'ye eklendi
            // Entity Framework kuruldu //db'ye eklendi
            // Migration'lar aktive edildi //db'ye eklendi
            // ASP.NET Identity entegrasyonu sağlandı. //db'ye eklendi
            // Concert class'ı oluşturuldu. //db'ye eklendi
            // Genre class'ı oluşturuldu. //db'ye eklendi
            // DbContext oluşturuldu. //db'ye eklendi
            // ApplicationUser, Concert, Genre arasındaki ilişkiler kuruldu //db'ye eklendi
            // Her bir class'ta navigation property'ler oluşturuldu //db'ye eklendi
            // Her Concert'in bir Genre'si olmalı. Dolayısıyla Concert'in GenreId ismindeki Foreign Key'i Required olarak belirlendi. [Required] data annotation'ı kullanıldı. İleride Fluent Api de kullanılacak bu gibi işlemler için //db'ye eklendi
            // Genre tablosuna örnek müzik türü isimleri eklenerek (pop, rock, metal vb.) tablo populate edildi (Genre için yönetim sistemi daha sonra eklenecek) //db'ye eklendi
            // ConcertController oluşturuldu //db'ye eklendi
            // Yeni Concert oluşturma View'u oluşturuldu //db'ye eklendi
            // Navbar'daki linkler düzenlendi, yeni linkler eklendi (Add a Concert bunlardan biri) //db'ye eklendi
            // Bazı bootstrap class'ları override edildi. Override edilen class'lar Site.cs dosyasına eklendi. Sitedeki tüm style'lar şu an Site.cs dosyasında bulunuyor //db'ye eklendi
            // Concert class'ının DateTime property'si var. Fakat biz kullanıcıdan Date ve Time değerlerini ayrı ayrı alacağız. Date, yani Tarih değeri, örneğin 3 ocak 2021 değeri alınacak, time property'sinde ise saat değeri alınacak, örneğin 14:00. Bunu yapabilmek için ConcertViewModel oluşturuldu. Bu Viewmodel, Concert class'ının tüm değerlerine sahip, bunun yanında Date ve Time property'lerine sahip //db'ye eklendi
            // ConcertViewModel'den gelen Date ve Time değerlerinin, Concert'in Datetime'sine parse edilmesi işlemi gerçekleştirildi //db'ye eklendi
            // Concert oluşturma sayfasında, genre seçimi için, tüm genre'lerin listelendiği bir dropdownlist oluşturuldu //db'ye eklendi
            // Bootstrap Button'larının default style'ları, siteyle uyumlu olacak şekilde override edildi //db'ye eklendi
            // Sisteme giriş yapmamış olan üyeler bazı ActionResult'lere ulaşamamalı. Bu yüzden bunlara [Authorize] attribute'ları eklendi //db'ye eklendi
            // Create [HttpPost] ActionResult'ı oluşturuldu ve ilk Concert kaydı veritabanına eklenmiş oldu. Good job bruh //db'ye eklendi
            // Create sayfası için client side validation oluşturuldu. Bunun için jQueryVal kullanıldı //db'ye eklendi
            // Log'lama, kullanılan teknolojiler vb için birer tablo oluşturuldu. Bu bilgiler veritabanına eklenmeye başlandı //db'ye eklendi
            // Partial view'lar eklendi //db'ye eklendi
            // Tasarım düzenlendi. Bol bol CSS, HTML Chore... //db'ye eklendi
            // Db'ye yeni bir concert eklenirken navigation property'ler kullanıldığı için, ekleme işlemini tamamlayabilmek için 3 sorgu atmamız gerekiyordu. Biz de foreign key'ler kullandık, gereksiz olan 2 sorguyu böylelikle sildik. //db'ye eklendi
            // BURAYA KADAR OK!
            
            // Birkaç Google Fontu projeye eklendi.
            // .NET Core'da ApplicationUser işlemleri farklı çalışıyor. ApplicationUser'a custom bir property eklendi, bu property'nin register sayfasında "görülmesi", form içinde veri doldurularak kaydın yapılması sağlandı.
            return View();
        }

        public IActionResult CampaignOfAddingNewModule()
        {
            // TextController'da bulunan tüm actionresultlar için bir tablo oluşturalım, görev yapıldıysa true yapalım property'sini, değilse false //db'ye eklendi
            // Yapılmış olan görevler yeşil, yapılmamışlar kırmızı renk ile gösterilsin, bu iki işlemi göstermek için icon'lar kullanalım //db'ye eklendi
            // Buton ile bu görevleri "yapıldı" diye işaretleyebilelim //db'ye eklendi
            // Görevleri "yapıldı, yapılmadı" olarak işaretleyebilme olayı Ajax post yapılabilir, belki de overkill olur bu, ileride düşünürüz
            // Görevlerin Türkçe ve İngilizce diye property'leri olsun. İngilizceye çevirdiklerimizi ingilizce property'sinde tutacağız
            // Sisteme konserler eklensin // db'ye eklendi
            // Kullanıcı, "katılacağım" diye belirttiği konserleri bir sayfa üzerinden takip edebilsin // db'ye eklendi
            // Kullanıcı, konserleri düzenleyebilsin
            // Date ve Time property'leri için özel validasyon oluşturuldu


            // Remove a gig
            // View All Upcoming Gigs
            // Search Implementation
            // Paging Implementation
            // View gig Details
            // View All upcoming gigs
            // View my upcoming gigs
            // Add a Gig to Calendar
            // Remove a Gig from Calendar
            // View Gigs I'm Attending
            // Follow an Artist
            // Unfollow an Artist
            // Who I'm Following
            // Takip ettiklerimi görüntüle
            // sanatçıları görüntüle
            // Gig Feed
            // CSS style ları
            // Genre için CRUD işlemleri yapılmak üzere admin paneli oluşturulmalı
            // Security Issues (XSS falan, bunları ekleyelim)
            // Kullanıcı, bir modülü sisteme eklediğinde, yani "tamamlandı" olarak işaretlediğinde, bunun tarihini görebilsin. Index sayfasında da "3 ay önce tamamlandı" şeklinde belirtebiliriz.
            // clean architecture
            // automated testing
            // Object-oriented Design
            // Restful APIs
            return View();
        }

        public IActionResult CampaignOfFixation() //ok
        {
            // Index sayfalarında tablo çok genişleyebiliyor property'lerin uzunluğuna göre. Bunlar düzenlenmeli. Trim metotları kullanılmalı //db'ye eklendi
            // Create Concert sayfasıdaki dropdown çalışmasına çalışıyor lakin görsel olarak dropdown'un içinde seçilen şey görünmüyor, dropdown'ın içi boş görünüyor //db'ye eklendi
            
            // Client side validation yapısında hata var. Normalde çalışıyor, ama Date ve Time değerleri bozuk girildiğinde çalışmıyor.
            // buton hover olunca text'i siyah oluyor. bunu silelim, kötü görünüyor
            // Google fontlarında türkçe karakter sıkıntısı var. Yeni fontlar bulunmalı
            // nav-bar da giriş yapan kişinin maili değil, ismi yazsın. Lakin yazamadık.
            return View();
        }

        public IActionResult DigerHicbirYereEklenmemis()
        {
            //View Model Pattern kullanmışız
            // Security olayları: SQL Injection casusluğuna mahal verilmiyor; Entity Framework kullanılıyor, dolayısıyla SQL sorguları Runtime'da oluşturulmuyor.
            return View();
        }

        public IActionResult NOT()
        {
            //nav-bar ın background-color'unu kırmızıdan #1b1313 siyaha çevirince süper oluyor. dropdown hover için açık ve koyu mavi renkler über manyak: #00c4ff   #004eff #0846d2
            return View();
        }
    }
}