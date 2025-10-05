using System;
using SimpleBlog.Repository;

namespace SimpleBlog.DependencyInjection;

public static class RepositoryConfiguration
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ILikeRepository, LikeRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        return services;
    }
}
