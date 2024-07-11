using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Dto
{
    public class MovieDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string DirectorName { get; set; }
        public List<string> Actors { get; set; }
        public List<string> Theatres { get; set; }
    }
}
