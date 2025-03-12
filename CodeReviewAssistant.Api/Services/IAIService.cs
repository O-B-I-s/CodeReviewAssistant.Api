namespace CodeReviewAssistant.Api.Services
{
    public interface IAIService
    {
        Task<string> AnalyzeCodeAsync(string codeSnippet);
    }
}
