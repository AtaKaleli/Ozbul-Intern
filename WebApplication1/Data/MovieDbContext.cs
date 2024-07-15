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
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId)
                .OnDelete(DeleteBehavior.Restrict); // Change cascade delete behavior
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(w => w.MovieActors)
                .HasForeignKey(ma => ma.ActorId)
                .OnDelete(DeleteBehavior.Restrict); // Change cascade delete behavior

            modelBuilder.Entity<MovieTheatre>()
                .HasKey(mt => new { mt.MovieId, mt.TheatreId });
            modelBuilder.Entity<MovieTheatre>()
                .HasOne(mt => mt.Movie) 
                
                .WithMany(m => m.MovieTheatres)
                .HasForeignKey(mt => mt.MovieId)
                .OnDelete(DeleteBehavior.Restrict); // Change cascade delete behavior
            modelBuilder.Entity<MovieTheatre>()
                .HasOne(mt => mt.Theatre)
                .WithMany(t => t.MovieTheatres)
                .HasForeignKey(mt => mt.TheatreId)
                .OnDelete(DeleteBehavior.Restrict); // Change cascade delete behavior

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.Restrict); // Change cascade delete behavior
        }
    }
}
