using System;
using SimpleBlog.Repository;

namespace SimpleBlog.DependencyInjection;

public static class RepositoryConfiguration
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        return services;
    }
}
