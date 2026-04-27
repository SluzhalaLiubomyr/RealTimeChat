
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace ChatApp.Infrastructure.Repositories;

/// <summary>
/// Repository for managing chat messages persistence.
/// </summary>
public class MessageRepository : IMessageRepository
{
    private readonly AppDbContext _context;

    public MessageRepository(AppDbContext context)
    {
        _context = context;
    }

    /// Adds a new message to the database.
    /// NOTE:
    /// Currently saves changes immediately.
    public async Task AddAsync(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }

    /// Retrieves all messages ordered by creation time.

    public async Task<List<Message>> GetAllAsync()
    {
        return await _context.Messages
            .OrderBy(x => x.CreatedAt)
            .ToListAsync();
    }
}