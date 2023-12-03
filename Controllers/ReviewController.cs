using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.HairdresserDomain.HairdresserDtos;
using HairdresserAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("review")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpPost("addReview")]
    public async Task<IActionResult> CreateReview([FromBody] ReviewDto review)
    {
        var createdReview = await _reviewService.CreateReviewAsync(review);
        return CreatedAtAction(nameof(GetReview), new { id = createdReview.Id }, createdReview);
    }

    [HttpGet("all/{id}")]
    public async Task<IActionResult> GetAllReviewsById(string id)
    {
        var reviews = await _reviewService.GetAllReviewsAsync(id);
        return Ok(reviews);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReview(Guid id)
    {
        var review = await _reviewService.GetReviewByIdAsync(id);
        if (review == null)
        {
            return NotFound();
        }
        return Ok(review);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReview(Guid id, [FromBody] Review review)
    {
        if (id != review.Id)
        {
            return BadRequest();
        }

        var existingReview = await _reviewService.GetReviewByIdAsync(id);
        if (existingReview == null)
        {
            return NotFound();
        }

        await _reviewService.UpdateReviewAsync(review);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(Guid id)
    {
        var review = await _reviewService.GetReviewByIdAsync(id);
        if (review == null)
        {
            return NotFound();
        }

        await _reviewService.DeleteReviewAsync(id);
        return NoContent();
    }
}
