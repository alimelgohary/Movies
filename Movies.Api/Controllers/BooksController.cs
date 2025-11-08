using Microsoft.AspNetCore.Mvc;
using Movies.Api.Mapping;
using Movies.Application.Models;
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
            IEnumerable<Movie> movies = await _movieRepository.GetAllMoviesAsync();
            MoviesResponse response = movies.ToMoviesResponse();
            return Ok(response);
        }
        
        [HttpGet(ApiEndpoints.Movies.GetById)]
        public async Task<ActionResult<MovieResponse>> GetById([FromRoute] Guid id)
        {
            Movie movie = await _movieRepository.GetMovieByIdAsync(id);
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
            Movie res = await _movieRepository.AddMovieAsync(movie);
            MovieResponse response = res.ToMovieResponse();
            return Ok(response);
        }

        [HttpPut(ApiEndpoints.Movies.Update)]
        public async Task<ActionResult<MovieResponse>> Update([FromRoute] Guid id, [FromBody] UpdateMovieRequest updateMovieRequest)
        {
            Movie movie = updateMovieRequest.ToMovie();
            Movie res = await _movieRepository.UpdateMovieAsync(movie, id);
            MovieResponse response = res.ToMovieResponse();
            return Ok(response);
        }

        [HttpDelete(ApiEndpoints.Movies.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _movieRepository.DeleteMovieByIdAsync(id);
            return NoContent();
        }
    }
}
