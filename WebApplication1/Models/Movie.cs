namespace WebApplication1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Worker Director { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<MovieTheatre> MovieTheatres { get; set; }


    }
}
