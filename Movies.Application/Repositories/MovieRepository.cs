using Movies.Application.Models;

namespace Movies.Application.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public List<Movie> _movies = new List<Movie>() {
            new Movie { Id = Guid.NewGuid(), Title = "Inception", Writer = "Christopher Nolan", PublicationYear = 2010, Genres = new List<string> { "Sci-Fi", "Thriller" } },
            new Movie { Id = Guid.NewGuid(), Title = "The Matrix", Writer = "The Wachowskis", PublicationYear = 1999, Genres = new List<string> { "Sci-Fi", "Action" } },
            new Movie { Id = Guid.NewGuid(), Title = "Interstellar", Writer = "Christopher Nolan", PublicationYear = 2014, Genres = new List<string> { "Sci-Fi", "Drama" } }
        };
        public Task<Movie> AddMovieAsync(Movie movie)
        {
            _movies.Add(movie);
            return Task.FromResult(movie);
        }

        public Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return Task.FromResult(_movies.AsEnumerable());
        }

        public Task<Movie?> GetMovieByIdAsync(Guid id)
        {
            return Task.FromResult(_movies.FirstOrDefault(m => m.Id == id));
        }
        public Task<Movie?> GetMovieBySlugAsync(string slug)
        {
            return Task.FromResult(_movies.FirstOrDefault(m => m.Slug == slug));
        }

        public Task<Movie> UpdateMovieAsync(Movie movie, Guid id)
        {
            if (id != movie.Id)
            {
                throw new ArgumentException("Movie ID mismatch");
            }
            var existingMovieIndex = _movies.FindIndex(x => x.Id == id);
            if (existingMovieIndex == -1)
            {
                throw new ArgumentException("Movie not found");
            }
            _movies[existingMovieIndex] = movie;
            return Task.FromResult(movie);
        }
        public Task DeleteMovieByIdAsync(Guid id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie is null)
            {
                throw new ArgumentException("Movie not found");
            }
            _movies.Remove(movie);
            return Task.CompletedTask;
        }
    }
}
