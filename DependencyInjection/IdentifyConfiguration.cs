using System;
using SimpleBlog.Data;
using SimpleBlog.Models.Domain;

namespace SimpleBlog.DependencyInjection;

public static class IdentifyConfiguration
{
    public static IServiceCollection AddIdentify(this IServiceCollection services)
    {
        services.AddDefaultIdentity<User>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
        })
        .AddEntityFrameworkStores<AppDbContext>();
        return services;
    }
}
