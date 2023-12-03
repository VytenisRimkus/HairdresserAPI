using HairdresserAPI.HairdresserDomain.Aggregate;
using HairdresserAPI.HairdresserDomain.HairdresserDtos;

namespace HairdresserAPI.Interfaces;
public interface IReviewService
{
    Task<Review> CreateReviewAsync(ReviewDto review);
    Task<IEnumerable<Review>> GetAllReviewsAsync(string id);
    Task<Review> GetReviewByIdAsync(Guid id);
    Task UpdateReviewAsync(Review review);
    Task DeleteReviewAsync(Guid id);
}
