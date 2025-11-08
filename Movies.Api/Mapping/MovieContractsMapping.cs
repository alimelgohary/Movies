using Movies.Contracts;
using Movies.Application.Models;
namespace Movies.Api.Mapping
{
    public static class MovieContractsMapping
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
    }
}
