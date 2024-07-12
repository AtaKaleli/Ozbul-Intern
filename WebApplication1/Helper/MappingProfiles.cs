using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.FirstName + " " + src.Director.LastName))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor.FirstName + " " + ma.Actor.LastName).ToList()))
                .ForMember(dest => dest.Theatres, opt => opt.MapFrom(src => src.MovieTheatres.Select(mt => mt.Theatre.Name).ToList()));

            CreateMap<CreateMovieDto, Movie>();
            CreateMap<Worker, WorkerDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));  // Map enum to string
            CreateMap<WorkerDto, Worker>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse(typeof(Role), src.Role)));  // Map string back to enum

            CreateMap<Theatre, TheatreDto>();
            CreateMap<TheatreDto, Theatre>();
        }
    }
}
