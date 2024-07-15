using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Interfaces
{
    public interface IWorkerRepository
    {
        List<Worker> GetWorkers();
        Worker GetWorkerById(int id);
        bool CreateWorker(Worker worker);
        bool DeleteWorker(Worker worker);
        bool UpdateWorker(Worker worker);
        bool Save();

    }
}
