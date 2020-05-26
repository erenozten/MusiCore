using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusiCore.Models;
using MusiCore.TextModels;

namespace MusiCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<CampaignOfAddingNewModule> CampaignOfAddingNewModules { get; set; }
        public DbSet<LogOfEverything> LogOfEverythings { get; set; }
        public DbSet<UsedApproach> UsedApproaches { get; set; }
        public DbSet<UsedTechnology> UsedTechnologies { get; set; }
        public DbSet<CampaignOfFixation> CampaignOfFixations { get; set; }

        //ben ekledim
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}
    }
}
