
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Theatre>))]
        public IActionResult GetTheatres()
        {
            var theatres = _theatreRepository.GetTheatres();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(theatres);
        }
    }
}