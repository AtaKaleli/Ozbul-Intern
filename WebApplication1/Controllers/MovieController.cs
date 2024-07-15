﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using System.Collections.Generic;
using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IWorkerRepository _workerRepository;

        public MovieController(IMovieRepository movieRepository, IMapper mapper, IWorkerRepository workerRepository)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _workerRepository = workerRepository;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _mapper.Map<List<MovieDto>>(_movieRepository.GetMovies());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _mapper.Map<MovieDto>(_movieRepository.GetMovieById(id));
            if (movie == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieDto movieDto)
        {
            if (movieDto == null)
                return BadRequest(ModelState);

            var director = _workerRepository.GetWorkerById(movieDto.DirectorId);
            if (director == null || director.Role != Role.Director)
            {
                ModelState.AddModelError("DirectorId", "The specified DirectorId is invalid or the worker is not a director.");
                return BadRequest(ModelState);
            }

            var movie = _mapper.Map<Movie>(movieDto);

            if (!_movieRepository.CreateMovie(movie))
            {
                ModelState.AddModelError("", "Something went wrong while saving the movie.");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null)
                return NotFound();

            if (!_movieRepository.DeleteMovie(movie))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the movie.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
        {
            
            var existingMovie = _movieRepository.GetMovieById(id);
            if (existingMovie == null)
                return NotFound();

            var director = _workerRepository.GetWorkerById(movieDto.DirectorId);
            if (director == null || director.Role != Role.Director)
            {
                ModelState.AddModelError("DirectorId", "The specified DirectorId is invalid or the worker is not a director.");
                return BadRequest(ModelState);
            }

            var movieToUpdate = _mapper.Map(movieDto, existingMovie);

            if (!_movieRepository.Save())
            {
                ModelState.AddModelError("", "Something went wrong while updating the movie.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
