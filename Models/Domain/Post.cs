namespace SimpleBlog.Models.Domain;

public class Post
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public string? Slug { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsPublished { get; set; } = true;
    public string? ShortDescription { get; set; }
    public string? FeaturedImageUrl { get; set; }

    // Navigation properties
    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Tag> Tags { get; set; } = [];
    public ICollection<Like> Likes { get; set; } = [];
}
