namespace WebApplication1.Models
{
    public class MovieActor
    {
        public virtual int MovieId { get; set; }
        public virtual int ActorId { get; set; }
        public virtual Movie Movie { get; set; }
        public  virtual Worker Actor { get; set; }
    }
}
