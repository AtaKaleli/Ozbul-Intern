using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Interfaces
{
    public interface IWorkerRepository
    {
        ICollection<Worker> GetWorkers();
    }
}
