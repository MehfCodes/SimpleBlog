using System;
using SimpleBlog.Models.Domain;

namespace SimpleBlog.Repository;

public interface ILikeRepository
{
    Task AddLikeAsync(Like like);
    Task RemoveLikeAsync(Guid postId, Guid userId);
    Task<bool> HasUserLikedAsync(Guid postId, Guid userId);
    Task<int> CountLikesAsync(Guid postId);
}
