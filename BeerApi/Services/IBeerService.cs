using BeerApi.DTO;
using BeerApi.Models;

namespace BeerApi.Services
{
    public interface IBeerService
    {
        Task<IEnumerable<Beer>> GetAllBeersAsync();
        Task<Beer> GetBeerByNameAsync(string name);
        Task<Beer> AddBeerAsync(BeerDTO beerDTO);
        Task<Beer> UpdateBeerRatingAsync(int beerId, int rating);
    }
}
