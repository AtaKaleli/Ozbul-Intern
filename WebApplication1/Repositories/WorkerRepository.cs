
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
        public bool CreateWorker(Worker worker)
        {
            _context.Add(worker);
            return Save();
        }

        public bool DeleteWorker(Worker worker)
        {
            _context.Remove(worker);
            return Save();
        }
        public bool UpdateWorker(Worker worker)  
        {
            _context.Update(worker);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

    }
}