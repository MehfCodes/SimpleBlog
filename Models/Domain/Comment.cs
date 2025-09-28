using System;

namespace SimpleBlog.Models.Domain;

public class Comment
{
    public Guid Id { get; set; }
    public required string AuthorName { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign key
    public Guid PostId { get; set; }
    public required Post Post { get; set; }
}
