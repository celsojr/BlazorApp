using SqliteWasmHelper;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class ThingContext : DbContext
    {
        public DbSet<Thing> Things { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<ThingTag> ThingTags { get; set; } = null!;

        public ThingContext(DbContextOptions<ThingContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Things)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<ThingTag>()
                .HasKey(tt => new { tt.ThingId, tt.TagId });

            modelBuilder.Entity<ThingTag>()
                .HasOne(tt => tt.Thing)
                .WithMany(t => t.ThingTags)
                .HasForeignKey(tt => tt.ThingId);

            modelBuilder.Entity<ThingTag>()
                .HasOne(tt => tt.Tag)
                .WithMany(t => t.ThingTags)
                .HasForeignKey(tt => tt.TagId);

            base.OnModelCreating(modelBuilder);
        }

        public async Task SeedDataAsync(ISqliteWasmDbContextFactory<ThingContext> contextFactory, HttpClient httpClient)
        {
            var seedFiles = new[] { "seed.sql" }; // Add more files if needed

            foreach (var file in seedFiles)
            {
                try
                {
                    var response = await httpClient.GetAsync($"api/seeds/{file}");
                    if (response.IsSuccessStatusCode)
                    {
                        var sqlScript = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(sqlScript))
                        {
                            using var ctx = await contextFactory.CreateDbContextAsync();
                            await ctx.Database.ExecuteSqlRawAsync(sqlScript);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error seeding {file}: {ex.Message}");
                }
            }
        }

    }
}
