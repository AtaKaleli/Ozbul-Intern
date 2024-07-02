namespace WebApplication1.Models
{
    public class Worker
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }

    }

    public enum Role
    {
        Director,Actor
    }
}
