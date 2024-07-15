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
                .Include(m => m.MovieActors)
                    .ThenInclude(ma => ma.Actor)
                .Include(m => m.MovieTheatres)
                    .ThenInclude(mt => mt.Theatre)
                .OrderBy(m => m.Id)
                .ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies
                .Include(m => m.Director)
                .Include(m => m.MovieActors)
                    .ThenInclude(ma => ma.Actor)
                .Include(m => m.MovieTheatres)
                    .ThenInclude(mt => mt.Theatre)
                .FirstOrDefault(m => m.Id == id);
        }
        public bool CreateMovie(Movie movie)
        {
            _context.Add(movie);
            return Save();
        }

        public bool DeleteMovie(Movie movie)
        {
            _context.Remove(movie);
            return Save();
        }

        public bool UpdateMovie(Movie movie)
        {
            _context.Update(movie);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
