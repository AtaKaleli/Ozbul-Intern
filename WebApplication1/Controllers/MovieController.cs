using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController:Controller
    {
        private readonly IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        
        [HttpGet]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Movie>))]
        public IActionResult GetMovies()
        {
            var movies = _movieRepository.GetMovies();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(movies);
        }
    }
}
