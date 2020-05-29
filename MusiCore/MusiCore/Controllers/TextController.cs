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
            // Projede kullanılan teknolojilerin, tekniklerin belirtilecek olduğu ActionResult

            // Proje .NET CORE 3.1 ile oluşturuldu //db'ye eklendi
            // Entity Framework kullanıldı //db'ye eklendi
            // Migration'lar kullanıldı //db'ye eklendi
            // Client Side Validation entegrasyonu yapıldı //db'ye eklendi
            // ASP.NET Identity entegrasyonu yapıldı (Kaydol, Giriş Yap, Çıkış Yap, Şifre Değiştir) //db'ye eklendi
            // Partial View'lar kullanıldı //db'ye eklendi
            // Bootstrap kullanıldı //db'ye eklendi
            // Proje .NET Core'da geliştirildiği için XSS saldırılarını bertaraf edebiliyor; JavaScript inputlarını default olarak reddediyor //db'ye eklendi
            // Bundling yapısı kullanıldı (request load time'ı azaltmak için)
            // EF Code-First yapısı kullanıldı //db'ye eklendi
            // CSRF saldırıları AntiForgeryToken sayesinde kolaylıkla önlenebiliyor //db'ye eklendi
            // SQL Injection casusluğu önleniyor. Projede Entity Framework kullanılıyor, dolayısıyla SQL sorguları Runtime'da değil, compile-time'da oluşturuluyor //db'ye eklendi

            // BURAYA KADAR OK!

            // Data Annotations (bunu sonlara ekle)

            return View();
        }

        public IActionResult UsedApproach() //ok
        {
            // Projede benimsenen yaklaşımlarla ilgili kısa notların yazıldığı ActionResult

            // Migration'lar küçük modüller halinde oluşturuldu. Dolayısıyla veritabanı problemleri yaşama olasılığı azaltıldı //db'ye eklendi
            // Proje bir müzik projesi olduğu için, yani gençlere hitap edeceği için tasarımda canlı renklere yer verildi //db'ye eklendi
            // Artistik tasarım uygulanmaya çalışıldı //db'ye eklendi

            // BURAYA KADAR OK!
            //
            //
            //
            return View();
        }

        public IActionResult LogOfEverything() //ok
        {
            // Projeye eklenen çıkarılan her şeyin log'landığı ActionResult

            // Proje başlatıldı. Roket kalkışa hazırlanıyor //db'ye eklendi
            // Proje GitHub'a eklendi //db'ye eklendi
            // ConnectionString oluşturuldu //db'ye eklendi
            // Entity Framework kuruldu //db'ye eklendi
            // Migration'lar aktive edildi //db'ye eklendi
            // ASP.NET Identity entegrasyonu sağlandı //db'ye eklendi
            // Concert class'ı oluşturuldu //db'ye eklendi
            // Genre class'ı oluşturuldu //db'ye eklendi
            // DbContext oluşturuldu //db'ye eklendi
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
            // Sisteme giriş yapmamış olan üyeler bazı ActionResult'lara ulaşamamalı. Bu yüzden bunlara [Authorize] attribute'ları eklendi //db'ye eklendi
            // Create [HttpPost] ActionResult'ı oluşturuldu ve ilk Concert kaydı veritabanına eklenmiş oldu. Good job bruh //db'ye eklendi
            // Create sayfası için client side validation oluşturuldu. Bunun için jQueryVal kullanıldı //db'ye eklendi
            // Log'lama, kullanılan teknolojiler vb için birer tablo oluşturuldu. Bu bilgiler veritabanına eklenmeye başlandı //db'ye eklendi
            // Partial view'lar eklendi //db'ye eklendi
            // Tasarım düzenlendi. Bol bol CSS, HTML Chore... //db'ye eklendi
            // Db'ye yeni bir concert eklenirken navigation property'ler kullanıldığı için, ekleme işlemini tamamlayabilmek için 3 sorgu atmamız gerekiyordu Biz de foreign key'ler kullandık, gereksiz olan 2 sorguyu böylelikle sildik. //db'ye eklendi
            // Birkaç Google Fontu projeye eklendi (bunlardan birisi Lato) //db'ye eklendi
            // ApplicationUser'a custom bir property eklendi, bu property'nin register sayfasında "görülmesi", form içinde veri doldurularak kaydın yapılması sağlandı //db'ye eklendi
            // Concert'lerin listelendiği sayfada, yani index'te, her bir konseri listelerken, konseri, sanatçıyı, konser yerini ve tarihi gösteren ikonumsu bir yapı oluşturuldu. İlgili CSS dosyaları site.css sayfasına eklendi //db'ye eklendi
            // Attendance class'ı oluşturuldu (Katılım). Bir Attendance-> Bir Concert ve bir ApplicationUser barındırır. Bunların foreign key'leri composite key'lerdir. Çünkü bir Attendance, özel olmalıdır: İki foreign key'in kombinasyonları özel olmalıdır, bundan bir tane daha olmamalıdır. Neden, çünkü bir katılım: bir konser ve bir katılımcıya aittir. Aynı konsere aynı katılımcı, ikinci kez katılım oluşturamaz; composite key bunun için oluşturuldu  //db'ye eklendi
            // Bir konsere birçok user katılabilir. O halde konser, ICollection<Attendance> a sahip olabilir. Bir user da birçok konsere katılımda bulunabilir. O halde user'in de ICollection<Attendance> ı olmalıdır //db'ye eklendi
            // Date ve Time property'leri için özel validasyon oluşturuldu //db'ye eklendi
            // one-to-many ilişkiler için fluent api oluşturuldu //db'ye eklendi
            // Concert ve Attendance arasındaki one-to-many ilişki için Fluent API oluşturuldu

            // BURAYA KADAR OLANLAR MODÜLLER SAYFASINA EKLENDİ KOPY PASTE İLE.
            // BURAYA KADAR OK!

            // Composite Key'ler için fluent api oluşturuldu
            // Warning giderildi 1
            // Cascade delete disable edildi
            // Attendance oluşturmak için API Controller oluşturuldu (AttendanceController)
            // Warning giderildi 2
            // Warning giderildi 3
            // Warning giderildi 4
            // Database adı değiştirildi, işler bozuldu. Eski veriler tekrar kaydedildi
            
            return View();
        }

        public IActionResult CampaignOfAddingNewModule()
        {
            // TextController'da bulunan tüm ActionResult'lar için bir tablo oluşturalım, görev yapıldıysa true yapalım property'sini, değilse false //db'ye eklendi
            // Yapılmış olan görevler yeşil, yapılmamışlar kırmızı renk ile gösterilsin, bu iki işlemi göstermek için icon'lar kullanalım //db'ye eklendi
            // Buton ile bu görevleri "yapıldı" diye işaretleyebilelim //db'ye eklendi
            // Görevleri "yapıldı, yapılmadı" olarak işaretleyebilme olayı Ajax post yapılabilir, belki de overkill olur bu, ileride düşünürüz
            // Görevlerin Türkçe ve İngilizce diye property'leri olsun. İngilizceye çevirdiklerimizi ingilizce property'sinde tutacağız
            // Sisteme konserler eklensin // db'ye eklendi
            // Kullanıcı, "katılacağım" diye belirttiği konserleri bir sayfa üzerinden takip edebilsin // db'ye eklendi
            // Kullanıcı, konserleri düzenleyebilsin // db'ye eklendi
            // Date ve Time property'leri için özel validasyon oluşturulsun // db'ye eklendi
            // Log'ların vb, ne zaman oluşturulduğunu index'te gösterelim. Örneğin: 5 ay önce // db'ye eklendi
            // Konser silme özelliği eklensin // db'ye eklendi
            // Tarihi geçmemiş olan konserler anasayfada listelensin // db'ye eklendi
            // Tarihi geçmiş olan konserler, anasayfada listelensin ama tarihi geçmiş olanlardan sonra listelensin veya bir butona tıklanınca, tarihi geçmiş olanlara yönlendirilsin // db'ye eklendi
            // Arama özelliği eklensin (Search) // db'ye eklendi
            // Paging özelliği eklensin // db'ye eklendi
            // Konser detaylarını görüntüleme özelliği eklensin // db'ye eklendi
            // Kullanıcı, katılacak olduğu konserleri özel bir sayfada görüntüleyebilsin // db'ye eklendi
            // Sanatçı, konser ekleyebilsin // db'ye eklendi
            // Sanatçı, konser silebilsin // db'ye eklendi
            // Kullanıcı, sanatçıyı takip edebilsin // db'ye eklendi
            // Kullanıcı, sanatçıyı takipten çıkarabilsin // db'ye eklendi
            // Kullanıcı, takip ettiği sanatçıları özel bir sayfada görebilsin // db'ye eklendi
            // Kullanıcının takip ve takipten çıkarma işlemleri tek tıkla halledilsin (jQuery ile) // db'ye eklendi
            // Sisteme müzik türü eklenebilsin (Genre) // db'ye eklendi
            // Sistemden müzik türü silinebilsin (Genre) // db'ye eklendi
            // Sistemdeki müzik türü görüntülenebilsin (Genre) // db'ye eklendi
            // Sistemdeki müzik türü güncellenebilsin (Genre) // db'ye eklendi
            // Kullanıcı, bir modülü sisteme eklediğinde, yani "tamamlandı" olarak işaretlediğinde, bunun tarihini görebilsin. Index sayfasında da "3 ay önce tamamlandı" şeklinde belirtebiliriz // db'ye eklendi
            // Sistem temiz bir mimariye sahip olsun; refaktörler yapılsın // db'ye eklendi
            // Test işlemleri yapılsın (Automated testing) // db'ye eklendi
            // Entity Framework sisteme entegre edilsin // db'ye eklendi
            // ASP.NET Identity entegrasyonu sağlansın // db'ye eklendi
            // Concert class'ı oluşturulsun // db'ye eklendi
            // Genre class'ı oluşturulsun // db'ye eklendi
            // DbContext oluşturulsun // db'ye eklendi
            // ApplicationUser, Concert, Genre arasındaki ilişkiler kurulsun // db'ye eklendi
            // Her bir class'ta navigation property'ler oluşturulsun // db'ye eklendi
            // Her Concert'in bir Genre'si olmalı. Dolayısıyla Concert'in GenreId ismindeki Foreign Key'i Required olarak belirlensin // db'ye eklendi
            // Genre tablosuna örnek müzik türü isimleri eklenerek (pop, rock, metal vb.) tablo populate edilsin (Genre için yönetim sistemi de daha sonra eklensin) // db'ye eklendi
            // ConcertController oluşturulsun ilgili ActionResult'lar oluşturulsun // db'ye eklendi
            // Navbar'daki linkler düzenlensin, yeni linkler eklensin (Add a Concert gibi) // db'ye eklendi
            // Bazı bootstrap class'ları override edilsin isteğe göre, istenen tasarıma göre. Override edilen class'lar Site.cs dosyasına eklensin. Sitedeki tüm style'lar şu an Site.cs dosyasında bulunuyor // db'ye eklendi
            // Concert class'ının DateTime property'si var. Fakat biz kullanıcıdan Date ve Time değerlerini ayrı ayrı alacağız. Date, yani Tarih değeri, örneğin 3 ocak 2021 değeri alınacak, time property'sinde ise saat değeri alınacak, örneğin 14:00. Bunu yapabilmek için ConcertViewModel oluşturulsun. Bu Viewmodel, Concert class'ının tüm değerlerine sahip olsun, bunun yanında Date ve Time property'lerine sahip olsun // db'ye eklendi
            // ConcertViewModel'den gelen Date ve Time değerlerinin, Concert'in Datetime'sine parse edilmesi işlemi gerçekleştirilsin // db'ye eklendi
            // Concert oluşturma sayfasında, genre seçimi için, tüm genre'lerin listelendiği bir dropdownlist oluşturulsun, genre buradan seçilsin ve kaydedilsin //db'ye eklendi
            // Sisteme giriş yapmamış olan üyeler bazı ActionResult'lara ulaşamamalı. Bu yüzden bunlara [Authorize] attribute'ları eklensin //db'ye eklendi
            // Create sayfası için client side validation oluşturulsun. Bunun için jQueryVal kullanılsın //db'ye eklendi
            // Log'lama, kullanılan teknolojiler vb için birer tablo oluşturulsun. Bu bilgiler veritabanına eklenmeye başlansın //db'ye eklendi
            // Kolay yönetim için Partial view'lar oluşturulsun //db'ye eklendi
            // Tasarım düzenlensin, çok sade, katı, ciddi bir görünüme sahip. Bunlar tersine çevrilsin //db'ye eklendi
            // Concert ile Genre, Concert ile artist arasında foreign key'ler oluşturulsun ve daha az sorgu ile veritabanına veri eklenebilsin //db'ye eklendi
            // Varsayılan font değiştirilsin, gençlere hitap eden canlı bir font bulunsun //db'ye eklendi
            // Identity'ye özel property'ler eklenebilsin, msdn'deki instruction takip edilsin //db'ye eklendi
            // Concert'lerin listelendiği sayfada, yani index'te, her bir konseri listelerken, konseri, sanatçıyı, konser yerini ve tarihi gösteren ikonumsu bir yapı oluşturulsun. İlgili CSS dosyaları site.css sayfasına eklensin //db'ye eklendi
            // One-to-many ilişkiler için fluent api kullanılsın //db'ye eklendi
            // Sadece tamamlanmış görevleri göster, sadece tamamlanmamış görevleri göster gibi paging işlemleri eklensin
            // Görevlere önem sırası koyalım. Enum yapabiliriz. 1,2 ve 3 ten oluşan önem sırası... 3 en önemsizi olsun. 1 en önemlisi. Index'te öneme göre sıralayalım. Ayrıca eklenme zamanına göre de sıralayabilelim

            // BURAYA KADAR OK!
            //Bootstrap bazı sayfalarda bozuk çalışıyor, görev sayfalarının indexlerinde problem var, let them be fixed!
            //
            return View();
        }

        public IActionResult CampaignOfFixation() //ok
        {
            // Index sayfalarında tablo çok genişleyebiliyor property'lerin uzunluğuna göre. Bunlar düzenlenmeli. Trim metotları kullanılmalı //db'ye eklendi
            // Create Concert sayfasıdaki dropdown çalışmasına çalışıyor lakin görsel olarak dropdown'un içinde seçilen şey görünmüyor, dropdown'ın içi boş görünüyor //db'ye eklendi

            // Client side validation yapısında hata var. Normalde çalışıyor, ama Date ve Time değerleri bozuk girildiğinde çalışmıyor //db'ye eklendi
            // buton hover olunca text'i siyah oluyor. bunu silelim, kötü görünüyor
            // Google fontlarında türkçe karakter sıkıntısı var. Yeni fontlar bulunmalı
            // nav-bar da giriş yapan kişinin maili değil, ismi yazsın
            // User register olayında: user ismini required yapalım
            
            // BURAYA KADAR OK!

            //
            //
            //
            return View();
        }

        public IActionResult DigerHicbirYereEklenmemis()
        {
            //View Model Pattern kullanmışız
            // Object-oriented Design
            // Restful APIs
            return View();
        }

        public IActionResult NOT()
        {
            //nav-bar ın background-color'unu kırmızıdan #1b1313 siyaha çevirince süper oluyor. dropdown hover için açık ve koyu mavi renkler über manyak: #00c4ff   #004eff #0846d2
            return View();
        }
    }
}