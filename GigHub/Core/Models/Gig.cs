using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GigHub.Core.Models
{
    // Konser
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        // Konseri veren Kullanıcı
        public ApplicationUser Artist { get; set; }

        // Konseri veren kullanıcının Id'si
        public string ArtistId { get; set; }

        // Konserin verilme zamanı
        public DateTime DateTime { get; set; }

        // Konserin verileceği yer
        public string Venue { get; set; }

        // Konserin türü
        public Genre Genre { get; set; }

        // Konserin türünün id değeri
        public byte GenreId { get; set; }

        // Konsere yapılan katılımlar. Dışarıdan bir liste set edilmesin diye private set olarak ayarlandı. 
        // Dolayısıyla eski liste, yeni bir listeyle değiştirilemeyecektir.
        public ICollection<Attendance> Attendances { get; private set; }

        // Default constructor. Konser initialize edildiği anda yeni bir Attendance listesi initialize etmemiz gerekiyor. Bunu yaptık.
        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        // Konser iptal edilirse Iscanceled = true olsun. 
        // Çünkü iptal edilen konseri sistemden silmeyeceğiz.
        public void Cancel()
        {
            IsCanceled = true;

            // Konserin iptal edildiğine dair bir bildirim oluşturuyoruz.
            var notification = Notification.GigCanceled(this);

            // Yukarıda oluşturulmuş olan "konser iptal edildi" içeriğine sahip bildirimi, konsere katılacak olan kullanıcılara gönderiyoruz.
            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Modify(DateTime dateTime, string venue, byte genre)
        {
            var notification = Notification.GigUpdated(this, DateTime, Venue);

            Venue = venue;
            DateTime = dateTime;
            GenreId = genre;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);
        }
    }
}