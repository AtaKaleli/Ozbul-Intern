using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IMovieRepository
    {
        ICollection<Movie> GetMovies();
    }
}
