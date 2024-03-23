using Microsoft.EntityFrameworkCore;

using Turboazmini.Models.Entities;

namespace Turboazmini.Entity
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
            : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Database=Turboaz;User Id=sa;Password=!Dquery20@4;Encrypt=false;App=Orm",
                opt =>
                {
                    opt.MigrationsHistoryTable("MigrationHistory");
                });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Model> Models { get; set; }
        public DbSet<Announcement> CarAnnouncements { get; set; }







    }
}






    
