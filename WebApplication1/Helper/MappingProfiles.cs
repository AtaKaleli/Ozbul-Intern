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
                 .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.FirstName + " " + src.Director.LastName))
                 .ForMember(dest => dest.MovieActors, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor.FirstName + " " + ma.Actor.LastName).ToList()))
                 .ForMember(dest => dest.MovieTheatres, opt => opt.MapFrom(src => src.MovieTheatres.Select(mt => mt.Theatre.Name).ToList()));


            CreateMap<CreateMovieDto, Movie>();
            CreateMap<Worker, WorkerDto>();
            CreateMap<WorkerDto, Worker>();
            CreateMap<Theatre, TheatreDto>();
            CreateMap<TheatreDto, Theatre>();
        }
    }
}
