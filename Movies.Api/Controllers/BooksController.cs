using Microsoft.AspNetCore.Mvc;
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
    }
}
