using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Interfaces
{
    public interface ITheatreRepository
    {
        ICollection<Theatre> GetTheatres();
    }
}
