using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Theatre
    {
        public int ID { get; set; }
        [Required]
        
        public Movie Movie { get; set; }
        [Required]

        public Movie[] Movies { get; set; }
        
        [Required]
        
        public string Location { get; set; }
        [Required]

        public string Name { get; set; }
    }
}
