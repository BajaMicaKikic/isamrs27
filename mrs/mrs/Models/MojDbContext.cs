//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace mrs.Models
{
    public class MojDbContext : DbContext
    {
        public MojDbContext() : base() { }
        public DbSet<UserAccount>  UserAccount { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            // modelBuilder.HasDefaultSchema("Admin");
            modelBuilder.Entity<UserAccount>().ToTable("Korisnici");
        }
    }
}
