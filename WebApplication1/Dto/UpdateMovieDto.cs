using System;

namespace WebApplication1.Dto
{
    public class UpdateMovieDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int DirectorId { get; set; }
    }
}

