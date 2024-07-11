﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using System.Collections.Generic;
using WebApplication1.Dto;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IMapper _mapper;

        public WorkerController(IWorkerRepository workerRepository, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
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

        [HttpPost]
        public IActionResult CreateWorker([FromBody] WorkerDto workerDto)
        {
            if (workerDto == null)
                return BadRequest(ModelState);

            var worker = _mapper.Map<Worker>(workerDto);

            if (!_workerRepository.CreateWorker(worker))
            {
                ModelState.AddModelError("", "Something went wrong while saving the worker.");
                return StatusCode(500, ModelState);
            }

            return CreatedAtAction("GetWorkerById", new { id = worker.Id }, worker);
        }
    }
}