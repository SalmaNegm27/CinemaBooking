using CinemaBooking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actor_Movie>()
        .HasKey(am => new { am.MovieId, am.ActorId });

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.Actor_Movies)
                .HasForeignKey(sc => sc.MovieId);

            modelBuilder.Entity<Actor_Movie>()
                .HasOne(am => am.Actor)
                .WithMany(c => c.Actor_Movies)
                .HasForeignKey(sc => sc.ActorId);

            modelBuilder.Entity<Actor_Movie>()
                .ToTable("Actor_Movies");
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> producers { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

    }
}
