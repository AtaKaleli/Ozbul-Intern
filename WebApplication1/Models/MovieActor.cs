namespace WebApplication1.Models
{
    public class MovieActor
    {
        public virtual int MovieId { get; set; }
        public virtual int ActorId { get; set; }
        public  Movie Movie { get; set; }
        public  Worker Actor { get; set; }
    }
}
