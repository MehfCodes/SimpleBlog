using System;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data;
using SimpleBlog.Models.Domain;

namespace SimpleBlog.Repository;

public class LikeRepository : ILikeRepository
{
    private readonly AppDbContext context;

    public LikeRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task AddLikeAsync(Like like)
    {
        context.Likes.Add(like);
        await context.SaveChangesAsync();
    }

    public async Task RemoveLikeAsync(Guid postId, Guid userId)
    {
        var like = await context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
        if (like != null)
        {
            context.Likes.Remove(like);
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> HasUserLikedAsync(Guid postId, Guid userId)
    {
        return await context.Likes.AnyAsync(l => l.PostId == postId && l.UserId == userId);
    }

    public async Task<int> CountLikesAsync(Guid postId)
    {
        return await context.Likes.CountAsync(l => l.PostId == postId);
    }
}
