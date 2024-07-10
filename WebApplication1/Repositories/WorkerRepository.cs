﻿
﻿using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly MovieDbContext _context;

        public WorkerRepository(MovieDbContext context)
        {
            _context = context;
        }

        public List<Worker> GetWorkers()
        {
            return _context.Workers.OrderBy(w => w.Id).ToList();
        }
        public Worker GetWorkerById(int id)
        {
            return _context.Workers
                .FirstOrDefault(w => w.Id == id); 
        }
    }
}