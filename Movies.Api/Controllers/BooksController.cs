using Microsoft.AspNetCore.Mvc;
using Movies.Api.Mapping;
using Movies.Application.Repositories;

namespace Movies.Api.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        public BooksController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        [HttpGet(ApiEndpoints.Movies.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            return Ok(movies);
        }
        
        [HttpGet(ApiEndpoints.Movies.GetById)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if(movie is null)
            {
                return NotFound();
            }
            var movieResponse = movie.ToMovieResponse();
            return Ok(movieResponse);
        }
    }
}
