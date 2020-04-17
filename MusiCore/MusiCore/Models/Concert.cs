using System;
using System.ComponentModel.DataAnnotations;

namespace MusiCore.Models
{
    public class Concert
    {
        public int Id { get; set; }

        // Bir konser, kesinlikle bir artist'e sahip olmalıdır. Bu yüzden [Required] data-annotation'ı kullanıldı.
        [Required]
        public ApplicationUser Artist { get; set; }
        public DateTime DateTime { get; set; }

        // Bir konser, kesinlikle bir venue'ye sahip olmalıdır. Bu yüzden [Required] data-annotation'ı kullanıldı.
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        // Bir konser, kesinlikle bir genre'ye sahip olmalıdır. Bu yüzden [Required] data-annotation'ı kullanıldı.
        [Required]
        public Genre Genre { get; set; }
    }
}