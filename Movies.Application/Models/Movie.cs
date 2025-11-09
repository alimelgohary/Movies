using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace Movies.Application.Models
{
    public partial class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public int PublicationYear { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public string Slug
        {
            get
            {
                return GenerateSlug();
            }
            set {}
        }
        private string GenerateSlug()
        {
            // var withoutSpecialChar = Regex.Replace(Title, "[^0-9A-Za-z _-]", string.Empty);
            
            var withoutSpecialChar = SlugRegex().Replace(Title, string.Empty);
            return withoutSpecialChar.ToLower().Replace(" ", "-") + "-" + PublicationYear;
            
        }
        // Partial method with GeneratedRegex attribute for better performance
        [GeneratedRegex("[^0-9A-Za-z _-]", RegexOptions.NonBacktracking, 10)]
        private static partial Regex SlugRegex();
    }
}
