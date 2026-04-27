using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using ChatApp.Infrastructure.Services;

namespace ChatApp.SignalR.Hubs;

/// <summary>
/// Real-time chat hub using SignalR.
/// Handles message broadcasting with sentiment analysis.
/// </summary>
public class ChatHub : Hub
{
    private readonly ISentimentService _sentiment;

    public ChatHub(ISentimentService sentiment)
    {
        _sentiment = sentiment;
    }

    /// Sends a message to all connected clients.
    public async Task SendMessage(string user, string text)
    {
        var sentiment = await _sentiment.AnalyzeAsync(text);

        await Clients.All.SendAsync("ReceiveMessage", new
        {
            user,
            text,
            sentiment = sentiment.ToString(),
            createdAt = DateTime.UtcNow
        });
    }
    
}