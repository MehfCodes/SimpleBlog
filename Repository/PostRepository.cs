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
        .OrderByDescending(p => p.CreatedAt)
        .ToListAsync();
    }
    public async Task<(IEnumerable<Post>, int TotalPage)> GetAllAsync(int page = 1, int pageSize = 9)
    {
        var totalPosts = await context.Posts.CountAsync();
        var totalPages = (int)Math.Ceiling(totalPosts / (double)pageSize);
        var posts = await context.Posts
        .Include(p => p.Author)
        .Include(p => p.Tags)
        .OrderByDescending(p => p.CreatedAt)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
        return(posts, totalPages);
    }

    public async Task<Post?> GetByIdAsync(Guid id)
    {
        return await context.Posts
        .Include(p => p.Author)
        .Include(p => p.Tags).Include(p => p.Likes)
        .Include(p => p.Comments)
            .ThenInclude(c => c.User)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateAsync(Post post)
    {
        context.Posts.Update(post);
        await context.SaveChangesAsync();
    }
    public async Task<IEnumerable<Post>> SearchAsync(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword)) return await GetAllAsync();
        var posts = await context.Posts
            .Include(p => p.Author)
            .Include(p => p.Tags)
            .Where(p => EF.Functions.Like(p.Title.ToLower(), $"%{keyword.ToLower()}%") ||
                        EF.Functions.Like(p.Content.ToLower(), $"%{keyword.ToLower()}%"))
            .ToListAsync();
        return posts;
    }
    public async Task<IEnumerable<Post>> GetByUserIdAsync(Guid userId)
    {
        return await context.Posts
            .Include(p => p.Author)
            .Include(p => p.Tags)
            .Where(p => p.AuthorId == userId)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }
    public async Task<(IEnumerable<Post>, int TotalPage)> GetByUserIdAsync(Guid userId, int page = 1, int pageSize = 9)
    {
        var totalPosts = await context.Posts.Where(p => p.AuthorId == userId).CountAsync();
        var totalPages = (int)Math.Ceiling(totalPosts / (double)pageSize);
        var posts = await context.Posts
            .Include(p => p.Author)
            .Include(p => p.Tags)
            .Where(p => p.AuthorId == userId)
            .OrderByDescending(p => p.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return(posts, totalPages);
    }
    public async Task<IEnumerable<Post>> GetRecentPostsAsync()
    {
        return await context.Posts
            .Include(p => p.Author)
            .Include(p => p.Tags)
            .OrderByDescending(p => p.CreatedAt)
            .Take(3)
            .ToListAsync();
    }

}
