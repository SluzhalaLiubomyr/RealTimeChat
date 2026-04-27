using ChatApp.Domain.Enums;

namespace ChatApp.Application.Interfaces;

/// <summary>
/// Provides sentiment analysis functionality.
/// </summary>
public interface ISentimentService
{
    /// Analyzes the sentiment of a given text.
    /// Implementation may use external services such as Azure Cognitive Services.
    Task<string> AnalyzeAsync(string message);
}