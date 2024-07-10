
﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerController(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        [HttpGet]
        public IActionResult GetWorkers()
        {
            var workers = _workerRepository.GetWorkers();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(workers);
        }

        [HttpGet("{id}")]
        public IActionResult GetWorkerById(int id)
        {
            var worker = _workerRepository.GetWorkerById(id);
            if (worker == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(worker);
        }
    }
}