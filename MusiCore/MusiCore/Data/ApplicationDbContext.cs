using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusiCore.Models;
using MusiCore.TextModels;

namespace MusiCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
        //    : base(options)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<CampaignOfAddingNewModule> CampaignOfAddingNewModules { get; set; }
        public DbSet<LogOfEverything> LogOfEverythings { get; set; }
        public DbSet<UsedApproach> UsedApproaches { get; set; }
        public DbSet<UsedTechnology> UsedTechnologies { get; set; }
        public DbSet<CampaignOfFixation> CampaignOfFixations { get; set; }

        //ben ekledim
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // cascading delete disable
            // Hata çıkarabilir ileride
            // google'dan: If you want to change the delete behavior for all relationships, then you can use this code in OnModelCreating(...) to bulk set it for all relationships in your model.
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Attendance>()
                .HasOne(e => e.Concert)
                .WithMany(c => c.Attendances);

            //Attendance class'ındaki Composite Key'leri oluşturduk (.NET Core'da data annotation'lar yeterli değilmiş bu işlem için; Fluent API gerekiyormuş)
            modelBuilder.Entity<Attendance>()
                .HasKey(c => new { c.ConcertId, c.AttendeeId });

            //ModelBuilder.Entity<Attendance>().has
            base.OnModelCreating(modelBuilder);
        }
    }
}
