namespace Movies.Contracts.Requests
{
    public class CreateMovieRequest
    {
        public required string Title { get; set; }
        public required string Writer { get; set; }
        public required int PublicationYear { get; set; }
        public required IEnumerable<string> Genres { get; set; } = Enumerable.Empty<string>();
    }
}
