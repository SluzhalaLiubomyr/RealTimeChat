using ChatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Persistence;

/// <summary>
/// EF Core database context.
/// Represents the application's database session and provides access to entities.
/// </summary>
public class AppDbContext : DbContext
{
    public DbSet<Message> Messages { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}