using Atelier.Domain.Models.BaseInfo;
using Atelier.Domain.Models.BaseInfo.Cities;
using Atelier.Domain.Models.BaseInfo.Groupings;
using Atelier.Domain.Models.BaseInfo.Ateliers;
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
        public DbSet<Grouping> Groupings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Domain.Models.BaseInfo.Ateliers.Atelier> Ateliers { get; set; }
        public DbSet<AtelierGroup> AtelierGroups { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}

