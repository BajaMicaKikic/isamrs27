using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mrs.ApplicationCore.Entities;

namespace mrs.Infrastructure.Data.Mapping
{
    public class ProjectionMap : IEntityTypeConfiguration<Projection>
    {
        public void Configure(EntityTypeBuilder<Projection> builder)
        {
            //Primary Key
            builder.HasKey(p => p.Id);
            //Properties
            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnName("ProjectionId").IsRequired();
            builder.Property(p => p.ProjectionName).HasColumnName("ProjectionName").IsUnicode().IsRequired();
            builder.Property(p => p.ActorId).HasColumnName("ActorId").IsRequired();
            builder.Property(p => p.GenreId).HasColumnName("GenreId").IsRequired();
            builder.Property(p => p.ProducerName).HasColumnName("ProducerName").IsUnicode().IsRequired();
            builder.Property(p => p.Duration).HasColumnName("Duration").IsRequired();
            //builder.Property(p => p.Poster).HasColumnName("Poster").IsRequired(false);
            builder.Property(p => p.ShortDescirption).HasColumnName("ShortDescription").IsUnicode().IsRequired();
            builder.Property(p => p.ProjectionType).HasColumnName("ProjectionType").IsRequired();
            //builder.Property(p => p.CultureObjectId).HasColumnName("CultureObjectId").IsRequired(); 
            //Relations
            builder.HasOne(p => p.Actor)
               .WithMany(a => a.Projections)
               .HasForeignKey(p => p.ActorId);

            builder.HasOne(p => p.Genre)
                .WithMany(g => g.Projections)
                .HasForeignKey(p => p.GenreId);

            //builder.HasOne(p => p.CultureObjects)
            //   .WithMany(c => c.Projections)
            //   .HasForeignKey(p => p.CultureObjectId);
            //Table
            builder.ToTable("Projections");
        }
    }
}
