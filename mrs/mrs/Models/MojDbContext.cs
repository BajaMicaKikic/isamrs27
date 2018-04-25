using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace mrs.Models
{
    public class MojDbContext : DbContext
    {
        public DbSet<UserAccount>  UserAccount { get; set; }
    }
}
