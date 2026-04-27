using Azure;
using Azure.AI.TextAnalytics;
using ChatApp.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ChatApp.Infrastructure.Services;

/// <summary>
/// Service responsible for sentiment analysis using Azure Cognitive Services.
/// </summary>
public class SentimentService : ISentimentService
{
    private readonly TextAnalyticsClient _client;

    public SentimentService(IConfiguration config)
    {
        var endpoint = config["AzureTextAnalytics:Endpoint"];
        var key = config["AzureTextAnalytics:Key"];

        _client = new TextAnalyticsClient(
            new Uri(endpoint),
            new AzureKeyCredential(key));
    }


    /// Analyzes message sentiment (Positive, Neutral, Negative).
    /// returns Detected sentiment as string.
    public Task<string> AnalyzeAsync(string message)
    {
        var result = _client.AnalyzeSentiment(message);

        return Task.FromResult(result.Value.Sentiment.ToString());
    }
}