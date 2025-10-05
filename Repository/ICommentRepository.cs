using System;
using SimpleBlog.Models.Domain;

namespace SimpleBlog.Repository;

public interface ICommentRepository
{
    Task AddCommentAsync(Comment comment);
    Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid postId);
}
