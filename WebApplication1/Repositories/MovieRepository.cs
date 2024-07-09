using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;
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
            return _context.Movies.OrderBy(m => m.Id).ToList();
        }
    }
}
