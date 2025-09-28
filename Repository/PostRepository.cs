using System;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data;
using SimpleBlog.Models.Domain;

namespace SimpleBlog.Repository;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext context;

    public PostRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task AddAsync(Post post)
    {
        await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var record = await context.Posts.FindAsync(id);
        if (record is not null)
        {
            context.Posts.Remove(record);
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await context.Posts.AnyAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        return await context.Posts
        .Include(p => p.Author)
        .Include(p => p.Tags)
        .ToListAsync();
    }

    public async Task<Post?> GetByIdAsync(Guid id)
    {
        return await context.Posts
        .Include(p => p.Author)
        .Include(p => p.Tags).Include(p => p.Likes)
        .Include(p => p.Comments)
            .ThenInclude(c => c.Author)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Post post)
    {
        context.Posts.Update(post);
        await context.SaveChangesAsync();
    }
}
