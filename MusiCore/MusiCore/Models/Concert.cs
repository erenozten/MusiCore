using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusiCore.Models
{
    public class Concert
    {
        public int Id { get; set; }

        // Bir konser, kesinlikle bir artist'e sahip olmalıdır. Bu yüzden [Required] data-annotation'ı kullanıldı. Edit: Required attribute'unu Foreign Key olan ArtistId ye taşıdık. Buradaki required silindi.
        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        // Bir konser, kesinlikle bir venue'ye sahip olmalıdır. Bu yüzden [Required] data-annotation'ı kullanıldı.
        [Required]
        [StringLength(255)]
        [Display(Name = "Mekan")]
        public string Venue { get; set; }

        // Bir konser, kesinlikle bir genre'ye sahip olmalıdır. Bu yüzden [Required] data-annotation'ı kullanıldı.
        // Foreign key'leri değil, navigasyon property'leri required yapmış olduk.
        //
        public Genre Genre { get; set; }

       [Required]
        public byte GenreId { get; set; }

        // ben ekledim
        // Attendance'ların içinden ConcertId'si Concert'in Id değerine eşit olan tüm attendance'ları aşağıdaki property sayesinde çekebiliyoruz sorguyla.
        public ICollection<Attendance> Attendances { get; set; }

        public string GetCroppedVenue
        {
            get
            {
                if (Venue.Length > 8)
                {
                    try
                    {
                        string subString = Venue.Substring(0, 5);
                        string newString = subString + "...";
                        return newString;
                    }
                    catch (Exception e)
                    {
                        return Venue;
                    }
                }
                else
                {
                    return Venue;
                }
            }
        }
    }
}