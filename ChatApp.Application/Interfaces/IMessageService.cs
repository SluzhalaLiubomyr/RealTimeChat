using ChatApp.Application.DTOs;

namespace ChatApp.Application.Interfaces;
/// <summary>
/// Provides business logic for managing chat messages.
/// </summary>
public interface IMessageService
{
    /// Creates a new message and processes it (e.g., sentiment analysis).
    Task<MessageDto> CreateAsync(string user, string text);

    /// Retrieves all messages for display.
    /// returns List of message DTOs.
    Task<List<MessageDto>> GetAllAsync();
}

