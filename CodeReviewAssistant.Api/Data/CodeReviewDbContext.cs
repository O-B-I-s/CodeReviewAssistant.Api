using CodeReviewAssistant.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeReviewAssistant.Api.Data
{
    public class CodeReviewDbContext : DbContext
    {
        public CodeReviewDbContext(DbContextOptions<CodeReviewDbContext> options)
            : base(options)
        {
        }

        // Add a parameterless constructor for design-time migrations
        public CodeReviewDbContext() { }

        public DbSet<CodeReview> CodeReviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodeReviewAssistant;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }
}
