using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data;
using SimpleBlog.Models.Domain;

namespace SimpleBlog.DependencyInjection;

public static class DbConfiguration
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        return services;
    }

    public static async Task SeedDatabaseAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var scopedServices = scope.ServiceProvider;

        var context = scopedServices.GetRequiredService<AppDbContext>();
        var userManager = scopedServices.GetRequiredService<UserManager<ApplicationUser>>();

        // seed data
        await SeedData.InitializeAsync(context, userManager);
    }
}
