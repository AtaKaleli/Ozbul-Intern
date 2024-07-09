using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Interfaces
{
    public interface ITheatreRepository
    {
        List<Theatre> GetTheatres();
    }
}
