using System;
using SimpleBlog.Models.Domain;

namespace SimpleBlog.Repository;

public interface ITagRepository
{
    Task<IEnumerable<Tag>> GetAllAsync();
    Task<Tag?> GetByIdAsync(Guid id);
    Task AddAsync(Tag tag);
    Task UpdateAsync(Tag tag);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}
