using HairdresserAPI.HairdresserDomain.Aggregate;

namespace HairdresserAPI.Interfaces;

public interface IReviewRepository
{
    Task AddAsync(Review review);
    Task<List<Review>> GetAllByIdAsync(string id);
    Task<Review> GetByIdAsync(Guid id);
    Task UpdateAsync(Review review);
    Task DeleteAsync(Guid id);
}
