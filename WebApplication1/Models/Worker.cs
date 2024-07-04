using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
