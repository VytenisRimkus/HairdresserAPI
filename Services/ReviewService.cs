using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.HairdresserDomain.HairdresserDtos;
using HairdresserAPI.Interfaces;

namespace HairdresserAPI.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<Review> CreateReviewAsync(ReviewDto review)
    {
        var newReview = new Review(review.Content, review.Rating, Guid.Parse(review.HairdresserId), Guid.Parse(review.UserId));
        await _reviewRepository.AddAsync(newReview);
        return newReview;
    }

    public async Task<IEnumerable<Review>> GetAllReviewsAsync(string id)
    {
        return await _reviewRepository.GetAllByIdAsync(id);
    }

    public async Task<Review> GetReviewByIdAsync(Guid id)
    {
        return await _reviewRepository.GetByIdAsync(id);
    }

    public async Task UpdateReviewAsync(Review review)
    {
        await _reviewRepository.UpdateAsync(review);
    }

    public async Task DeleteReviewAsync(Guid id)
    {
        await _reviewRepository.DeleteAsync(id);
    }
}
