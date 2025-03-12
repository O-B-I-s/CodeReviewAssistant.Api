using CodeReviewAssistant.Api.Models;
using OpenAI.Chat;


public class AiCodeReviewService
{
    private readonly string apiKey;

    public AiCodeReviewService()
    {
    }

    public AiCodeReviewService(IConfiguration configuration)
    {
        apiKey = configuration["OpenAI:ApiKey"];
    }

    public async Task<CodeReview> ReviewCodeAsync(string codeSnippet, string language, string? aiResponse)
    {
        try
        {
            var openAiClient = new ChatClient("gpt-4o", apiKey);

            string prompt = $"Review this {language} code for security, best practices, and improvements.\n\n Your response should be in HTML format like Bolds, lists, headers etc (Don't add this text :```html Code Review):\n\n{codeSnippet}";

            var completionRequest = new UserChatMessage(prompt);

            var result = await openAiClient.CompleteChatAsync(completionRequest);
            aiResponse = result?.Value?.Content?.LastOrDefault()?.Text;

            if (string.IsNullOrEmpty(aiResponse))
                throw new Exception("AI response was empty");

            return new CodeReview { ReviewComments = aiResponse, CodeSnippet = codeSnippet, Language = language };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"AI Review Error: {ex.Message}");
            throw;
        }
    }
}
