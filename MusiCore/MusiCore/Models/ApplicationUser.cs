using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MusiCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Followers = new Collection<Following>(); // Takipçiler'i işaret eden follow'lar (Following)
            Followees = new Collection<Following>(); // Takip Edilenler'i işaret eden follow'lar (Following)
        }

        //[Required]
        //[StringLength(100)]
        public string Name { get; set; }

        public ICollection<Following> Followers { get; set; }
        public ICollection<Following> Followees { get; set; }
    }
}
