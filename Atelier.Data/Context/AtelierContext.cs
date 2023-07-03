using Atelier.Domain.Models.BaseInfo;
using Microsoft.EntityFrameworkCore;

namespace Atelier.Data.Context
{
    public class AtelierContext : DbContext
    {
        public AtelierContext(DbContextOptions<AtelierContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}

