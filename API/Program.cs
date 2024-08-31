

using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API 
{
    public class Program 
    {
    public static async Task Main(string[] args) 
    {
        var host = CreateHostBuilder(args).Build();
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<DataContext>();
            var userManager = services.GetRequiredService<UserManager<AppUser>>(); // pt Microsoft.AspNetCore.Identity;
            var roleManager = services.GetRequiredService<RoleManager<AppRole>>(); // pt Microsoft.AspNetCore.Identity;
            await context.Database.MigrateAsync();
            await Seed.SeedUsers(userManager, roleManager); // context
        }
        catch (Exception ex)
        {
            var logger = services.GetService<ILogger<Program>>();
            logger.LogError(ex, "An error occured during migration.");
        }
        
        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStartup<Startup>();
            });
    }
}
