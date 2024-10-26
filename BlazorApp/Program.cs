using BlazorApp.Data;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

namespace BlazorApp
{https://github.com/celsojr/BlazorApp/pull/3/conflict?name=BlazorApp%252Fwwwroot%252Fapi%252Fseeds%252Fseed.sql&base_oid=537402e333f8fd0923d763d1e038d4f2c2b4b546&head_oid=b3dd561faf93e60a93c725aa811f8f62923defea
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddScoped<NavigationService>();

            builder.Services.AddSqliteWasmDbContextFactory<ThingContext>(
                opts => opts.UseSqlite("Data Source=Things.sqlite3"));

            builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var host = builder.Build();

            var dbContextFactory = host.Services.GetRequiredService<ISqliteWasmDbContextFactory<ThingContext>>();
            var httpClient = host.Services.GetRequiredService<HttpClient>();

            using var ctx = await dbContextFactory.CreateDbContextAsync();
            await ctx.SeedDataAsync(dbContextFactory, httpClient);

            await host.RunAsync();
        }
    }
}
