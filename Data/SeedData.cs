using SimpleBlog.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SimpleBlog.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            await context.Database.MigrateAsync();

            // Users
            if (!context.Users.Any())
            {
                var users = new List<ApplicationUser>
                {
                    new() { UserName = "alice", Email = "alice@example.com" },
                    new() { UserName = "bob", Email = "bob@example.com" },
                    new() { UserName = "charlie", Email = "charlie@example.com" },
                    new() { UserName = "david", Email = "david@example.com" }
                };

                foreach (var u in users)
                {
                    await userManager.CreateAsync(u, "@Password123!");
                }
            }

            var allUsers = await context.Users.ToListAsync();

            // Tags
            if (!context.Tags.Any())
            {
                var tags = new List<Tag>
                {
                    new() { Name = "CSharp" },
                    new() { Name = "MVC" },
                    new() { Name = "EFCore" },
                    new() { Name = "DotNet" }
                };
                context.Tags.AddRange(tags);
                await context.SaveChangesAsync();
            }

            var allTags = await context.Tags.ToListAsync();

            // Posts
            if (!context.Posts.Any())
            {
                var posts = new List<Post>
                {
                    new() { Id = Guid.NewGuid(), Title = "Hello World", Content = "First post content", Author = allUsers[0], CreatedAt = DateTime.UtcNow, Tags = new List<Tag> { allTags[0], allTags[1] } },
                    new() { Id = Guid.NewGuid(), Title = "Learning MVC", Content = "MVC basics", Author = allUsers[1], CreatedAt = DateTime.UtcNow, Tags = new List<Tag> { allTags[1] } },
                    new() { Id = Guid.NewGuid(), Title = "EF Core Tips", Content = "EF Core guide", Author = allUsers[2], CreatedAt = DateTime.UtcNow, Tags = new List<Tag> { allTags[2] } },
                    new() { Id = Guid.NewGuid(), Title = "DotNet 8 Features", Content = ".NET 8 new stuff", Author = allUsers[3], CreatedAt = DateTime.UtcNow, Tags = new List<Tag> { allTags[3] } }
                };
                context.Posts.AddRange(posts);
                await context.SaveChangesAsync();
            }

            var allPosts = await context.Posts.Include(p => p.Author).ToListAsync();

            // Comments
            if (!context.Comments.Any())
            {
                var comments = new List<Comment>
                {
                    new() { Content = "Great post!", Post = allPosts[0], Author = allUsers[1], CreatedAt = DateTime.UtcNow },
                    new() { Content = "Thanks for sharing", Post = allPosts[1], Author = allUsers[0], CreatedAt = DateTime.UtcNow },
                    new() { Content = "Very useful", Post = allPosts[2], Author = allUsers[3], CreatedAt = DateTime.UtcNow },
                    new() { Content = "Nice article", Post = allPosts[3], Author = allUsers[2], CreatedAt = DateTime.UtcNow }
                };
                context.Comments.AddRange(comments);
                await context.SaveChangesAsync();
            }

            // Likes
            if (!context.Likes.Any())
            {
                var likes = new List<Like>
                {
                    new() { Post = allPosts[0], Author = allUsers[2] },
                    new() { Post = allPosts[1], Author = allUsers[3] },
                    new() { Post = allPosts[2], Author = allUsers[0] },
                    new() { Post = allPosts[3], Author = allUsers[1] }
                };
                context.Likes.AddRange(likes);
                await context.SaveChangesAsync();
            }
        }
    }
}
