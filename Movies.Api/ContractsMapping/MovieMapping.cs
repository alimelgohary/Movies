using Movies.Contracts;
using Movies.Application.Models;
using Movies.Contracts.Requests;
namespace Movies.Api.Mapping
{
    public static class MovieMapping
    {
        public static MovieResponse ToMovieResponse(this Movie movie)
        {
            return new MovieResponse
            {
                MovieId = movie.Id,
                MovieTitle = movie.Title,
                MovieWriter = movie.Writer,
                MoviePublicationYear = movie.PublicationYear,
                MovieGenres = movie.Genres.ToList()
            };
        }
        public static Movie ToMovie(this CreateMovieRequest movie)
        {
            return new Movie
            {
                Id = Guid.NewGuid(),
                Title = movie.Title,
                Writer = movie.Writer,
                PublicationYear = movie.PublicationYear,
                Genres = movie.Genres.ToList()
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
                Genres = movie.Genres.ToList()
            };
        }
    }
}
