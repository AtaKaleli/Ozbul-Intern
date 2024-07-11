using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using System.Collections.Generic;
using WebApplication1.Dto;
using AutoMapper;

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
    }
}