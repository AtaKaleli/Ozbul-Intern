using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Interfaces
{
    public interface ITheatreRepository
    {
        List<Theatre> GetTheatres();
        Theatre GetTheatreById(int id);
        bool CreateTheatre(Theatre theatre);
        bool DeleteTheatre(Theatre theatre);
        bool Save();

    }
}
