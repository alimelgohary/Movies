using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contracts.Requests
{
    public class UpdateMovieRequest
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Writer { get; set; }
        public required int PublicationYear { get; set; }
        public required IEnumerable<string> Genres { get; set; } = Enumerable.Empty<string>();
    }
}
