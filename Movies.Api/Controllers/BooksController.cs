using Microsoft.AspNetCore.Mvc;
using Movies.Api.Mapping;
using Movies.Application.Repositories;
using Movies.Contracts;
using Movies.Contracts.Requests;

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
        public async Task<ActionResult<MovieResponse>> GetAllAsync()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            return Ok(movies);
        }
        
        [HttpGet(ApiEndpoints.Movies.GetById)]
        public async Task<ActionResult<MovieResponse>> GetById([FromRoute] Guid id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if(movie is null)
            {
                return NotFound();
            }
            var movieResponse = movie.ToMovieResponse();
            return Ok(movieResponse);
        }
        [HttpPost(ApiEndpoints.Movies.Create)]
        public async Task<ActionResult<MovieResponse>> Create([FromBody] CreateMovieRequest createMovieRequest)
        {
            var movie = createMovieRequest.ToMovie();
            var res = await _movieRepository.AddMovieAsync(movie);
            
            return Ok(res.ToMovieResponse());
        }

        [HttpPut(ApiEndpoints.Movies.Update)]
        public async Task<ActionResult<MovieResponse>> Update([FromRoute] Guid id, [FromBody] UpdateMovieRequest updateMovieRequest)
        {
            var movie = updateMovieRequest.ToMovie();
            var res = await _movieRepository.UpdateMovieAsync(movie, id);
            return Ok(res.ToMovieResponse());
        }

        [HttpDelete(ApiEndpoints.Movies.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _movieRepository.DeleteMovieByIdAsync(id);
            return NoContent();
        }
    }
}
