using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DanteOnSafari
{
    public partial class SafariVacationContext : DbContext
    {
        public SafariVacationContext()
        {
        }

        public SafariVacationContext(DbContextOptions<SafariVacationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("server=localhost;database=SafariVacation");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
        }
        public DbSet<Animal> SeenAnimals {get; set;}
    }
}
