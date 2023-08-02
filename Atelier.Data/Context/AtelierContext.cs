using System.Linq;
using Atelier.Data.Seeder;
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
	        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
		        .SelectMany(t => t.GetForeignKeys())
		        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

	        foreach (var fk in cascadeFKs)
		        fk.DeleteBehavior = DeleteBehavior.Restrict;

			modelBuilder.Entity<Grouping>().HasQueryFilter(u => u.DeletedDate == null);
			modelBuilder.Entity<City>().HasQueryFilter(u => u.DeletedDate == null);






            var assembly = typeof(UserSeeder).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
	}

}

