using WebApplication1.Models;

namespace WebApplication1.Dto
{
    public class WorkerDto
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public List<string> Movies { get; set; }
        public List<string> Actors { get; set; }
    }
}
