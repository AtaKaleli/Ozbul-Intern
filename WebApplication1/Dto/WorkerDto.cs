using WebApplication1.Models;

namespace WebApplication1.Dto
{
    public class WorkerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public List<string> Movies { get; set; }
        public List<string> Actors { get; set; }
    }
}
