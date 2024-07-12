using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Models;
using System;
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
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))  // Combine first name and last name
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))  // Map enum to string
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Movie.Name).Distinct().ToList()))  // Map movies
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor.FirstName + " " + ma.Actor.LastName).Distinct().ToList()));  // Map actors

            CreateMap<WorkerDto, Worker>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => SplitFirstName(src.Name)))  // Split name back to first name
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => SplitLastName(src.Name)))  // Split name back to last name
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.Parse(typeof(Role), src.Role)));  // Map string back to enum

            CreateMap<Theatre, TheatreDto>();
            CreateMap<TheatreDto, Theatre>();
        }

        private string SplitFirstName(string name)
        {
            return name.Split(' ')[0];
        }

        private string SplitLastName(string name)
        {
            var parts = name.Split(' ');
            return string.Join(" ", parts.Skip(1));
        }
    }
}
