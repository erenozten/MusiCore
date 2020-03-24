using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusiCore.Models
{
    public class MusiCoreDbContext: DbContext
    {
        public MusiCoreDbContext(DbContextOptions<MusiCoreDbContext> options)
            : base(options)
        {
            //constructor'u bu şekilde yazmalıyız.
        }

        public DbSet<Gig> Gigs { get; set; }

    }
}
