using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace WebApplication1.Models
{
    public class MovieTheatre
    {
        public virtual int MovieId { get; set; }
        public virtual int TheatreId { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Theatre Theatre { get; set; }
    }
}
