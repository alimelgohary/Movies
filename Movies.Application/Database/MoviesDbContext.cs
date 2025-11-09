using Microsoft.EntityFrameworkCore;
using Movies.Application.Models;

namespace Movies.Application.Database
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoviesDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
