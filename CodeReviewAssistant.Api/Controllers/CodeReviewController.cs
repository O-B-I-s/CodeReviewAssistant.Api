using CodeReviewAssistant.Api.Models;
using CodeReviewAssistant.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeReviewAssistant.Api.Controllers
{
    [ApiController]
    [Route("api/codereview")]
    public class CodeReviewController : ControllerBase
    {
        private readonly ICodeReviewService _service;
        private readonly AiCodeReviewService _aiService;

        public CodeReviewController(ICodeReviewService service)
        {
            _service = service;
            _aiService = new AiCodeReviewService();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeReview>>> GetAllReviews()
        {
            return Ok(await _service.GetAllReviewsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CodeReview>> GetReview(int id)
        {
            var review = await _service.GetReviewByIdAsync(id);
            if (review == null) return NotFound();
            return Ok(review);
        }

        [HttpPost("submit")]
        public async Task<ActionResult> SubmitReview([FromBody] CodeReview review)
        {
            if (review == null) return BadRequest();
            await _service.AddReviewAsync(review);
            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
        }

        [HttpPost("review")]
        public async Task<IActionResult> ReviewCode([FromBody] CodeReview request)
        {
            if (string.IsNullOrEmpty(request.CodeSnippet))
                return BadRequest("Code snippet is required");

            try
            {
                var review = await _aiService.ReviewCodeAsync(request.CodeSnippet, request.Language, request.ReviewComments);
                await _service.AddReviewAsync(review);

                return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
