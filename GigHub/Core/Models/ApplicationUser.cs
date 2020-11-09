using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GigHub.Core.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        // Kullanıcının takipçileri
        public ICollection<Following> Followers { get; set; }
        
        // Kullanıcıyı takip edenler
        public ICollection<Following> Followees { get; set; }
        
        // Kullanıcı bildirimleri
        public ICollection<UserNotification> UserNotifications { get; set; }

        public ApplicationUser()
        {
            // Followers ICollection'ının itinialization'ı:
            Followers = new Collection<Following>();

            // Followees ICollection'ının itinialization'ı:
            Followees = new Collection<Following>();

            // UserNotifications ICollection'ının initialization'ı
            UserNotifications = new Collection<UserNotification>(); 
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public void Notify(Notification notification)
        {
            //Kullanıcı bilgilendirme:
            UserNotifications.Add(new UserNotification(this, notification));
        }
    }
}