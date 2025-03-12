using CodeReviewAssistant.Api.Data;
using CodeReviewAssistant.Api.Models;
using CodeReviewAssistant.Api.Repositoreis;
using Microsoft.EntityFrameworkCore;

namespace CodeReviewAssistant.Api.Repositories
{
    public class CodeReviewRepository : ICodeReviewRepository
    {
        private readonly CodeReviewDbContext _context;

        public CodeReviewRepository(CodeReviewDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CodeReview>> GetAllReviewsAsync()
        {
            return await _context.CodeReviews.ToListAsync();
        }

        public async Task<CodeReview> GetReviewByIdAsync(int id)
        {
            return await _context.CodeReviews.FindAsync(id);
        }

        public async Task AddReviewAsync(CodeReview review)
        {
            await _context.CodeReviews.AddAsync(review);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
