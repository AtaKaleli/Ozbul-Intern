using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class MovieRepository:IMovieRepository
    {
        private readonly MovieDbContext _context;
        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public ICollection<Movie> GetMovies()
        {
            return _context.Movies.OrderBy(p => p.Id).ToList();
        }
    }
}
