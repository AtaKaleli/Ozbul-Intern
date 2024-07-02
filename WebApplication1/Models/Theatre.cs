namespace WebApplication1.Models
{
    public class Theatre
    {
        public int ID { get; set; }
        public Movie Movie { get; set; }
        public Movie[] Movies { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
    }
}
