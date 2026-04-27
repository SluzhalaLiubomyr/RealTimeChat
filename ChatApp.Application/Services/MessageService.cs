using ChatApp.Application.DTOs;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using ChatApp.Domain.Enums;

namespace ChatApp.Application.Services;


/// <summary>
/// Provides business logic for chat messages.
/// </summary>
public class MessageService : IMessageService
{
	private readonly IMessageRepository _repo;
	private readonly ISentimentService _sentiment;

	public MessageService(IMessageRepository repo, ISentimentService sentiment)
	{
		_repo = repo;
		_sentiment = sentiment;
	}

    /// Creates a new message with sentiment analysis.
    public async Task<MessageDto> CreateAsync(string user, string text)
	{
        var sentimentString = await _sentiment.AnalyzeAsync(text);
        var sentiment = Enum.Parse<SentimentType>(sentimentString, true);

        var message = new Message
		{
			UserId = user,
			Text = text,
			Sentiment = sentiment,
			CreatedAt = DateTime.UtcNow
		};

		await _repo.AddAsync(message);

		return new MessageDto
		{
			User = user,
			Text = text,
			Sentiment = sentiment.ToString(),
			CreatedAt = message.CreatedAt
		};
	}

    /// Returns all stored messages.
    public async Task<List<MessageDto>> GetAllAsync()
	{
		var messages = await _repo.GetAllAsync();

		return messages.Select(m => new MessageDto
		{
			User = m.UserId,
			Text = m.Text,
			Sentiment = m.Sentiment.ToString(),
			CreatedAt = m.CreatedAt
		}).ToList();
	}
}