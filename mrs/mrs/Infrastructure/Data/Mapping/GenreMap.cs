using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mrs.ApplicationCore.Entities;

namespace mrs.Infrastructure.Data.Mapping
{
    public class GenreMap : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            //Primary Key
            builder.HasKey(g => g.Id);
            //Properties
            builder.Property(g => g.Id).ValueGeneratedOnAdd().HasColumnName("GenreId").IsRequired();
            builder.Property(g => g.GenreName).HasColumnName("GenreName").IsUnicode().IsRequired();
            //Table
            builder.ToTable("Genres");
        }
    }
}

