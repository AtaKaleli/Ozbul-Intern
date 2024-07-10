
﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreRepository _theatreRepository;

        public TheatreController(ITheatreRepository theatreRepository)
        {
            _theatreRepository = theatreRepository;
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
            var theatre = _theatreRepository.GetTheatreById(id);
            if (theatre == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(theatre);
        }
    }
}