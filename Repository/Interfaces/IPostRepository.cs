using SimpleBlog.Models.Domain;

namespace SimpleBlog.Repository;

public interface IPostRepository
{
    Task AddAsync(Post post);
    Task<Post?> GetByIdAsync(Guid id);
    Task<IEnumerable<Post>> GetAllAsync();
    Task UpdateAsync(Post post);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<IEnumerable<Post>> SearchAsync(string keyword);
    Task<IEnumerable<Post>> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<Post>> GetRecentPostsAsync();
}
