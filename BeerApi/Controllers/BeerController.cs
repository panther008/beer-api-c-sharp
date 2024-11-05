using BeerApi.DTO;
using BeerApi.Models;
using BeerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _service;

        public BeerController(IBeerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beer>>> GetAllBeers()
        {
            return Ok(await _service.GetAllBeersAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<Beer>> SearchBeer([FromQuery] string name)
        {
            var beer = await _service.GetBeerByNameAsync(name);
            if (beer == null) return NotFound("Beer not found");
            return Ok(beer);
        }

        [HttpPost]
        public async Task<ActionResult<Beer>> AddBeer([FromBody] BeerDTO beerDTO)
        {
            var beer = await _service.AddBeerAsync(beerDTO);
            return CreatedAtAction(nameof(GetAllBeers), new { id = beer.Id }, beer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBeerRating(int id, [FromQuery] int rating)
        {
            var beer = await _service.UpdateBeerRatingAsync(id, rating);
            if (beer == null) return NotFound("Beer not found");
            return Ok(beer);
        }
    }
}
