using System;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data;

namespace SimpleBlog.DependencyInjection;

public static class DbConfiguration
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(config.GetConnectionString("DefaultConnection")));
        return services;
    }
}
