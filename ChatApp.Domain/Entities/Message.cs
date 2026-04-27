using ChatApp.Domain.Enums;

namespace ChatApp.Domain.Entities;

public class Message
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Text { get; set; }
    public SentimentType Sentiment { get; set; }
    public DateTime CreatedAt { get; set; }
}