using CodeReviewAssistant.Api.Models;
using CodeReviewAssistant.Api.Repositoreis;

namespace CodeReviewAssistant.Api.Services
{
    public class CodeReviewService : ICodeReviewService
    {
        private readonly ICodeReviewRepository _repository;

        public CodeReviewService(ICodeReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CodeReview>> GetAllReviewsAsync()
        {
            return await _repository.GetAllReviewsAsync();
        }

        public async Task<CodeReview> GetReviewByIdAsync(int id)
        {
            return await _repository.GetReviewByIdAsync(id);
        }

        public async Task AddReviewAsync(CodeReview review)
        {
            await _repository.AddReviewAsync(review);
            await _repository.SaveAsync();
        }
    }
}
