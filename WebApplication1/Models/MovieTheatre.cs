namespace WebApplication1.Models
{
    public class MovieTheatre
    {
        public int MovieId { get; set; }
        public int TheatreId { get; set; }
        public Movie Movie { get; set; }
        public Theatre Theatre { get; set; }
    }
}
