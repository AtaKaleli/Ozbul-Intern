using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using System.Collections.Generic;
using WebApplication1.Dto;
using AutoMapper;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreRepository _theatreRepository;
        private readonly IMapper _mapper;

        public TheatreController(ITheatreRepository theatreRepository, IMapper mapper)
        {
            _theatreRepository = theatreRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTheatres()
        {
            var theatres = _theatreRepository.GetTheatres();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(theatres);
        }

        [HttpGet("{id}")]
        public IActionResult GetTheatreById(int id)
        {
            var movie = _mapper.Map<MovieDto>(_theatreRepository.GetTheatreById(id));
            if (movie == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(movie);
        }

        [HttpPost]
        public IActionResult CreateTheatre([FromBody] TheatreDto theatreDto)
        {
            if (theatreDto == null)
                return BadRequest(ModelState);

            var theatre = _mapper.Map<Theatre>(theatreDto);

            if (!_theatreRepository.CreateTheatre(theatre))
            {
                ModelState.AddModelError("", "Something went wrong while saving the theatre.");
                return StatusCode(500, ModelState);
            }
            return CreatedAtAction("GetTheatreById", new { id = theatre.Id }, theatre);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTheatre(int id)
        {
            var theatre = _theatreRepository.GetTheatreById(id);
            if (theatre == null)
                return NotFound();

            if (!_theatreRepository.DeleteTheatre(theatre))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the theatre.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}