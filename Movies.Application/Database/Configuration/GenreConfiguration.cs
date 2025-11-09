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
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(m => m.Id);

            builder.Property(m => m.Name)
                   .HasMaxLength(200);
            builder.HasIndex(m => m.Name).IsUnique();
        }
    }
}
