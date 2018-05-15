namespace mrs.Infrastructure.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using mrs.ApplicationCore.Entities;

    public class ScreeningMap : IEntityTypeConfiguration<Screening>
    {
        public void Configure(EntityTypeBuilder<Screening> builder)
        {
            //Primary Key
            builder.HasKey(s => s.Id);
            //Properties
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("ScreeningId").IsRequired();
            builder.Property(s => s.ScreenStartDateTime).HasColumnName("ScreenStartDateTime").IsUnicode().IsRequired();
            builder.Property(s => s.ProjectionId).HasColumnName("ProjectionId").IsRequired();
            builder.Property(s => s.CultureObjectHallId ).HasColumnName("CultureObjectHallId").IsRequired();
            //Relations
            builder.HasOne(s => s.Projection)
               .WithMany(p => p.Screenings)
               .HasForeignKey(s => s.ProjectionId);

            builder.HasOne(s => s.CultureObjecsHall)
                .WithMany(co => co.Screenings)
                .HasForeignKey(s => s.CultureObjectHallId);
            //Table
            builder.ToTable("Screenings");
        }
    }
}

