using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class ThingContext : DbContext
    {
        public ThingContext(DbContextOptions<ThingContext> opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thing>().HasData(
                new Thing() { Id = 1, Name = "One thing" }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Thing> Things { get; set; } = null!;
    }
}
