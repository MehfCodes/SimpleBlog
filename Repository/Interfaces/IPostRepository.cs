using SimpleBlog.Models.Domain;

namespace SimpleBlog.Repository;

public interface IPostRepository
{
    Task AddAsync(Post post);
    Task<Post?> GetByIdAsync(Guid id);
    Task<IEnumerable<Post>> GetAllAsync();
    Task<(IEnumerable<Post>, int TotalPage)> GetAllAsync(int page = 1, int pageSize = 5);
    Task UpdateAsync(Post post);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<IEnumerable<Post>> SearchAsync(string keyword);
    Task<(IEnumerable<Post>, int TotalPage)> GetByUserIdAsync(Guid userId, int page = 1, int pageSize = 9);
    Task<IEnumerable<Post>> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<Post>> GetRecentPostsAsync();
}
