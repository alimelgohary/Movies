using Movies.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Repositories
{
    public interface IMovieRepository
    {
        public Task<IEnumerable<Movie>> GetAllMoviesAsync();
        public Task<Movie?> GetMovieByIdAsync(Guid id);
        public Task AddMovieAsync(Movie movie);
        public Task UpdateMovieAsync(Movie movie, Guid id);
        public Task DeleteMovieByIdAsync(Guid id);

    }
}
