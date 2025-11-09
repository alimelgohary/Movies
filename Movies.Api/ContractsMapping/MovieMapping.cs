using Movies.Contracts;
using Movies.Application.Models;
using Movies.Contracts.Requests;
namespace Movies.Api.Mapping
{
    public static class MovieMapping
    {
        public static MoviesResponse ToMoviesResponse(this IEnumerable<Movie> movie)
        {
            return new MoviesResponse
            {
                Items = movie.Select(m => m.ToMovieResponse())
            };
        }
        public static MovieResponse ToMovieResponse(this Movie movie)
        {
            return new MovieResponse
            {
                MovieId = movie.Id,
                MovieTitle = movie.Title,
                MovieWriter = movie.Writer,
                MovieSlug = movie.Slug,
                MoviePublicationYear = movie.PublicationYear,
                MovieGenres = movie.Genres.Select(x => x.Name).ToList()
            };
        }
        public static Movie ToMovie(this CreateMovieRequest request)
        {
            return new Movie
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Writer = request.Writer,
                PublicationYear = request.PublicationYear,
                Genres = request.Genres.Select(x => new Genre { Id = x }).ToList()
            };
        }
        public static Movie ToMovie(this UpdateMovieRequest movie)
        {
            return new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Writer = movie.Writer,
                PublicationYear = movie.PublicationYear,
                Genres = movie.Genres.Select(x => new Genre { Id = x }).ToList()
            };
        }
    }
}
