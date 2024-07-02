using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Worker
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public Role Role { get; set; }

    }

    public enum Role
    {
        Director,Actor
    }
}
