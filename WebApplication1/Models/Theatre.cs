namespace WebApplication1.Models
{
    public class Theatre
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public ICollection<MovieTheatre> MovieTheatres { get; set; }
    }
}
