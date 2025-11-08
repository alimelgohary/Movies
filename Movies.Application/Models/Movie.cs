using System;
using System.Collections.Generic;
using System.Linq;
namespace Movies.Application.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public int PublicationYear { get; set; }
        public IEnumerable<string> Genres{ get; set; } = Enumerable.Empty<string>();

    }
}
