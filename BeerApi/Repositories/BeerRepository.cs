using BeerApi.Data;
using BeerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerApi.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly BeerContext _context;

        public BeerRepository(BeerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Beer>> GetAllBeersAsync() => await _context.Beers.ToListAsync();

        public async Task<Beer> GetBeerByNameAsync(string name) =>
            await _context.Beers.FirstOrDefaultAsync(b => b.Name.Contains(name));

        public async Task<Beer> AddBeerAsync(Beer beer)
        {
            _context.Beers.Add(beer);
            await _context.SaveChangesAsync();
            return beer;
        }

        public async Task<Beer> UpdateBeerRatingAsync(int beerId, int rating)
        {
            var beer = await _context.Beers.FindAsync(beerId);
            if (beer == null) return null;

            beer.Ratings.Add(rating);
            beer.AverageRating = beer.Ratings.Average();
            await _context.SaveChangesAsync();
            return beer;
        }
    }
}
