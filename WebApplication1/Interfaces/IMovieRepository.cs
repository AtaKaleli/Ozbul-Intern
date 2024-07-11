using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();
        Movie GetMovieById(int id);
        bool CreateMovie(Movie movie);
        bool Save();
    }
}
