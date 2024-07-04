using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieTheatre> MovieTheatres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });
            modelBuilder.Entity<MovieActor>()
                .HasOne(m => m.Movie)
                .WithMany(ma => ma.MovieActors)
                .HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<MovieActor>()
                .HasOne(m => m.Actor)
                .WithMany(ma => ma.MovieActors)
                .HasForeignKey(m => m.ActorId);
            modelBuilder.Entity<MovieTheatre>()
                .HasKey(mt => new { mt.MovieId, mt.TheatreId });
            modelBuilder.Entity<MovieTheatre>()
                .HasOne(m => m.Movie)
                .WithMany(ma => ma.MovieTheatres)
                .HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<MovieTheatre>()
                .HasOne(m => m.Theatre)
                .WithMany(mt => mt.MovieTheatres)
                .HasForeignKey(m => m.TheatreId);
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId);
        }
    }
}
