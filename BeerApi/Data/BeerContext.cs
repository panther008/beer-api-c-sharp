using Microsoft.EntityFrameworkCore;
using BeerApi.Models;

namespace BeerApi.Data
{
    public class BeerContext : DbContext
    {
        public BeerContext(DbContextOptions<BeerContext> options) : base(options) { }
        public DbSet<Beer> Beers { get; set; }
    }
}
