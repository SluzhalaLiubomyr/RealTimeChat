namespace ChatApp.Application.DTOs;
public class MessageDto
{
    public string User { get; set; }
    public string Text { get; set; }
    public string Sentiment { get; set; }
    public DateTime CreatedAt { get; set; }
}