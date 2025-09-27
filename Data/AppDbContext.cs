using System;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Models.Domain;

namespace SimpleBlog.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Post> Posts { get; set; }
}
