using Moq;
using NUnit.Framework;
using WebApplication1.Interfaces;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helper;


namespace MovieNUnitTests
{
    public class MovieTests
    {
        private Mock<IMovieRepository> _mockMovieRepository;
        private Mock<IWorkerRepository> _mockWorkerRepository;
        private IMapper _mapper;
        private MovieController _movieController;

        [SetUp]
        public void Setup()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockWorkerRepository = new Mock<IWorkerRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>());
            _mapper = config.CreateMapper();
            _movieController = new MovieController(_mockMovieRepository.Object, _mapper, _mockWorkerRepository.Object);
        }

        [Test]
        public void GetMovieById_ExistingIdPassed_ReturnsOkResult()
        {
            var random = new Random();
            var movieId = random.Next(1, 1000);
            var movieName = Faker.Lorem.Sentence();
            var releaseDate = new DateTime(2010, 7, 16);
            var directorFirstName = Faker.Name.First();
            var directorLastName = Faker.Name.Last();

            var movie = new Movie
            {
                Id = movieId,
                Name = movieName,
                ReleaseDate = releaseDate,
                Director = new Worker
                {
                    Id = random.Next(1, 1000),
                    FirstName = directorFirstName,
                    LastName = directorLastName,
                    Role = Role.Director
                }
            };

            _mockMovieRepository.Setup(repo => repo.GetMovieById(movieId)).Returns(movie);

            var result = _movieController.GetMovieById(movieId) as OkObjectResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));

            var movieDto = result.Value as MovieDto;
            Assert.That(movieDto, Is.Not.Null);
            Assert.That(movieDto.Id, Is.EqualTo(movieId));
            Assert.That(movieDto.Name, Is.EqualTo(movieName));
            Assert.That(movieDto.ReleaseDate, Is.EqualTo(releaseDate));
            Assert.That(movieDto.DirectorName, Is.EqualTo($"{directorFirstName} {directorLastName}"));
        }

        [Test]
        public void GetMovieById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            var movieId = 1;
            _mockMovieRepository.Setup(repo => repo.GetMovieById(movieId)).Returns((Movie)null);

            var result = _movieController.GetMovieById(movieId);
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }
    }
}
