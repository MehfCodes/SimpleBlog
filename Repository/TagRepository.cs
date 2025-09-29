using System;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data;
using SimpleBlog.Models.Domain;

namespace SimpleBlog.Repository;

public class TagRepository
{
    private readonly AppDbContext context;

    public TagRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Tag>> GetAllAsync()
    {
        return await context.Tags.ToListAsync();
    }

    public async Task<Tag?> GetByIdAsync(Guid id)
    {
        return await context.Tags.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(Tag tag)
    {
        await context.Tags.AddAsync(tag);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tag tag)
    {
        context.Tags.Update(tag);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var record = await context.Tags.FindAsync(id);
        if (record is not null)
        {
            context.Tags.Remove(record);
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await context.Tags.AnyAsync(t => t.Id == id);
    }
}
