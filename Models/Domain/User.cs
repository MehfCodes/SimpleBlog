using System;
using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Models.Domain;

public class User : IdentityUser<Guid>
{
    public required string Username { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<Post> Posts { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Like> Likes { get; set; } = [];
}
