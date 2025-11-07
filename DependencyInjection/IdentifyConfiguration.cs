using System;
using Microsoft.AspNetCore.Identity;
using SimpleBlog.Data;
using SimpleBlog.Models.Domain;

namespace SimpleBlog.DependencyInjection;

public static class IdentifyConfiguration
{
    public static IServiceCollection AddIdentify(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/login";
            options.LogoutPath = "/logout";
            options.AccessDeniedPath = "/access-denied";
        });
        services.AddAuthentication()
        .AddGoogle(options =>
        {
            var googleAuthSection = configuration.GetSection("Authentication:Google");

            options.ClientId = googleAuthSection["ClientId"] ?? "";
            options.ClientSecret = googleAuthSection["ClientSecret"] ?? "";
        });

        return services;
    }
}
