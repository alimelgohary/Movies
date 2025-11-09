using Microsoft.AspNetCore.Mvc;
using Movies.Api.Mapping;
using Movies.Application.Models;
using Movies.Application.Repositories;
using Movies.Contracts;
using Movies.Contracts.Requests;

namespace Movies.Api.Controllers
{
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        [HttpGet(ApiEndpoints.Movies.GetAll)]
        public async Task<ActionResult<MovieResponse>> GetAllAsync(CancellationToken token)
        {
            IEnumerable<Movie> movies = await _movieRepository.GetAllMoviesAsync(token);
            MoviesResponse response = movies.ToMoviesResponse();
            return Ok(response);
        }
        
        [HttpGet(ApiEndpoints.Movies.Get)]
        public async Task<ActionResult<MovieResponse>> Get([FromRoute] string idOrSlug)
        {
            var movie = Guid.TryParse(idOrSlug, out Guid id) 
                ? await _movieRepository.GetMovieByIdAsync(id) 
                : await _movieRepository.GetMovieBySlugAsync(idOrSlug);

            if(movie is null)
            {
                return NotFound();
            }
            MovieResponse movieResponse = movie.ToMovieResponse();
            return Ok(movieResponse);
        }
        [HttpPost(ApiEndpoints.Movies.Create)]
        public async Task<ActionResult<MovieResponse>> Create([FromBody] CreateMovieRequest createMovieRequest)
        {
            Movie movie = createMovieRequest.ToMovie();
            Movie? res = await _movieRepository.AddMovieAsync(movie);
            if (res is null)
            {
                return BadRequest("One or more genres are invalid.");
            }
            MovieResponse response = res.ToMovieResponse();
            return Ok(response);
        }

        [HttpPut(ApiEndpoints.Movies.Update)]
        public async Task<ActionResult<MovieResponse>> Update([FromRoute] Guid id, [FromBody] UpdateMovieRequest updateMovieRequest)
        {
            Movie movie = updateMovieRequest.ToMovie();
            Movie? res = await _movieRepository.UpdateMovieAsync(movie, id);
            if(res is null)
                return BadRequest("One or more genres are invalid.");

            MovieResponse response = res.ToMovieResponse();
            return Ok(response);
        }

        [HttpDelete(ApiEndpoints.Movies.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _movieRepository.DeleteMovieByIdAsync(id);
            if(!result)
                return NotFound();
            return NoContent();
        }
    }
}
