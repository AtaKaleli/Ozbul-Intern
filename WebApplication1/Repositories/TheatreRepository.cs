﻿using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Repositories
{
    public class TheatreRepository : ITheatreRepository
    {
        private readonly MovieDbContext _context;

        public TheatreRepository(MovieDbContext context)
        {
            _context = context;
        }

        public List<Theatre> GetTheatres()
        {
            return _context.Theatres.OrderBy(t => t.Id).ToList();
        }
        public Theatre GetTheatreById(int id)
        {
            return _context.Theatres
                .FirstOrDefault(t => t.Id == id); 
        }
    }
}