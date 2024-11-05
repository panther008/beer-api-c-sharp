using BeerApi.DTO;
using BeerApi.Models;
using BeerApi.Repositories;

namespace BeerApi.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _repository;

        public BeerService(IBeerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Beer>> GetAllBeersAsync() => await _repository.GetAllBeersAsync();

        public async Task<Beer> GetBeerByNameAsync(string name) => await _repository.GetBeerByNameAsync(name);

        public async Task<Beer> AddBeerAsync(BeerDTO beerDTO)
        {
            var beer = new Beer
            {
                Name = beerDTO.Name,
                Type = beerDTO.Type
            };

            if (beerDTO.Rating.HasValue)
            {
                beer.Ratings.Add(beerDTO.Rating.Value);
                beer.AverageRating = beer.Ratings.Average();
            }

            return await _repository.AddBeerAsync(beer);
        }

        public async Task<Beer> UpdateBeerRatingAsync(int beerId, int rating) =>
            await _repository.UpdateBeerRatingAsync(beerId, rating);
    }
}
