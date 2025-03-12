using CodeReviewAssistant.Api.Models;

namespace CodeReviewAssistant.Api.Repositoreis
{
    public interface ICodeReviewRepository
    {
        Task<IEnumerable<CodeReview>> GetAllReviewsAsync();
        Task<CodeReview> GetReviewByIdAsync(int id);
        Task AddReviewAsync(CodeReview review);
        Task SaveAsync();
    }
}
