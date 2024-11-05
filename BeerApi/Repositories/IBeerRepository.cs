using BeerApi.Models;

namespace BeerApi.Repositories
{
    public interface IBeerRepository
    {
        Task<IEnumerable<Beer>> GetAllBeersAsync();
        Task<Beer> GetBeerByNameAsync(string name);
        Task<Beer> AddBeerAsync(Beer beer);
        Task<Beer> UpdateBeerRatingAsync(int beerId, int rating);
    }
}
