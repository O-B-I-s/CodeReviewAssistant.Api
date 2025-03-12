using CodeReviewAssistant.Api.Models;

namespace CodeReviewAssistant.Api.Services
{
    public interface ICodeReviewService
    {
        Task<IEnumerable<CodeReview>> GetAllReviewsAsync();
        Task<CodeReview> GetReviewByIdAsync(int id);
        Task AddReviewAsync(CodeReview review);
    }
}
