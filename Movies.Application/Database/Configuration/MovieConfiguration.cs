using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Database.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Id);

            builder.Property(m => m.Title)
                   .HasMaxLength(200);
            builder.Property(m => m.Writer)
                     .HasMaxLength(100);

            builder.Property(m => m.PublicationYear);
            
            // add check constraint for PublicationYear to be between 1888 and current year
            builder.ToTable(t=> t.HasCheckConstraint("CK_Movie_PublicationYear", $"PublicationYear >= 1888 AND PublicationYear <= YEAR(GETDATE())"));

            builder.Property(m => m.Slug)
                        .HasMaxLength(205);

            builder.HasIndex(m => m.Slug)
                     .IsUnique();

            builder.HasMany(m => m.Genres)
                   .WithMany(g => g.Movies)
                   .UsingEntity(j => j.ToTable("MovieGenres"));

        }
    }
}
