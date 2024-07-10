using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;
        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public List<Movie> GetMovies()
        {
            return _context.Movies
                .Include(m => m.Director)
                .OrderBy(m => m.Id)
                .ToList();
        }
        public Movie GetMovieById(int id)
        {
            return _context.Movies
                .Include(m => m.Director)
                .FirstOrDefault(m => m.Id == id);
        }
    }
}
