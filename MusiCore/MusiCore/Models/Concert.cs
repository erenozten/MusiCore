using System;
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
    }
}