using Microsoft.EntityFrameworkCore;
using Movies.Application.Database;
using Movies.Application.Models;

namespace Movies.Application.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesDbContext _context;
        public MovieRepository(MoviesDbContext context)
        {
            _context = context;
        }
        public async Task<Movie?> AddMovieAsync(Movie movie)
        {
            var genreIds = movie.Genres.Select(g => g.Id).ToList();
            var existingGenres = await _context.Genres
                .Where(g => genreIds.Contains(g.Id)).ToListAsync();

            if (existingGenres.Count != genreIds.Count)
                return null;

            movie.Genres = existingGenres;
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync(CancellationToken token = default)
        {
            return await _context.Movies
                .AsNoTrackingWithIdentityResolution()
                .Include(x => x.Genres)
                .ToListAsync(cancellationToken: token);
        }

        public async Task<Movie?> GetMovieByIdAsync(Guid id)
        {
            return await _context.Movies
                .AsNoTrackingWithIdentityResolution()
                .Include(x => x.Genres)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
        public Task<Movie?> GetMovieBySlugAsync(string slug)
        {
            return _context.Movies
                .AsNoTrackingWithIdentityResolution()
                .Include(x => x.Genres)
                .FirstOrDefaultAsync(m => m.Slug == slug);
        }

        public async Task<Movie?> UpdateMovieAsync(Movie movie, Guid id)
        {

            if (movie.Id != id)
                return null;

            var movieFromDb = await _context.Movies
                .Include(x => x.Genres)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movieFromDb is null)
                return null;

            var genreIds = movie.Genres.Select(g => g.Id).ToList();
            var existingGenres = await _context.Genres
                .Where(g => genreIds.Contains(g.Id)).ToListAsync();

            if (existingGenres.Count != genreIds.Count)
                return null;

            movieFromDb.Genres = existingGenres;
            movieFromDb.Title = movie.Title;
            movieFromDb.Writer = movie.Writer;
            movieFromDb.PublicationYear = movie.PublicationYear;

            await _context.SaveChangesAsync();
            return movieFromDb;
        }
        public async Task<bool> DeleteMovieByIdAsync(Guid id)
        {
            var movieFromDb = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movieFromDb is null)
                return false;

            _context.Movies.Remove(movieFromDb);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
