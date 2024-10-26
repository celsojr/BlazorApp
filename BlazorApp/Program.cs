using BlazorApp.Data;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

namespace BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddScoped<NavigationService>();

            builder.Services.AddSqliteWasmDbContextFactory<ThingContext>(
                opts => opts.UseSqlite("Data Source=things.sqlite3"));

            builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var host = builder.Build();

            // Resolve the factory and create an instance to seed data
            var dbContextFactory = host.Services.GetRequiredService<ISqliteWasmDbContextFactory<ThingContext>>();
            var httpClient = host.Services.GetRequiredService<HttpClient>();

            // Create a new ThingContext for seeding
            using var ctx = await dbContextFactory.CreateDbContextAsync();
            await ctx.SeedDataAsync(dbContextFactory, httpClient);

            await host.RunAsync();
        }
    }
}
