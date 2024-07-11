using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.FirstName + " " + src.Director.LastName));

            CreateMap<CreateMovieDto, Movie>();
            CreateMap<Worker, WorkerDto>();
            CreateMap<Theatre, TheatreDto>();
        }
    }
}
