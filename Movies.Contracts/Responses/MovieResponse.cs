namespace Movies.Contracts
{
    public class MovieResponse
    {
        public Guid MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieWriter { get; set; }
        public int MoviePublicationYear { get; set; }
        public IEnumerable<string> MovieGenres { get; set; } = Enumerable.Empty<string>();

    }
}
