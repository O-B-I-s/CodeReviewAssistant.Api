namespace CodeReviewAssistant.Api.Models
{
    public class CodeReview
    {
        public int Id { get; set; }
        public string? CodeSnippet { get; set; } // Code submitted for review
        public string? ReviewComments { get; set; } // AI-generated comments
        public string? Language { get; set; } // e.g., C#, JavaScript
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
