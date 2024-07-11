using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _movieRepository.GetMovies();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] Movie movie)
        {
            // the error part can be divided for more clarity later on If asked me to do
            if (movie == null || !_movieRepository.CreateMovie(movie))
                return BadRequest(ModelState);

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }
    }
}
