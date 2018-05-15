
namespace mrs.Infrastructure.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using mrs.ApplicationCore.Entities;
    public class SeatMap : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            // Primary Key
            builder.HasKey(s => s.Id);
            // Properties
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("SeatId").IsRequired();
            builder.Property(s => s.Row).HasColumnName("RowNumber").IsRequired();
            builder.Property(s => s.SeatNumber).HasColumnName("SeatNumber").IsRequired();
            builder.Property(s => s.HallSegmentId).HasColumnName("HallSegmentid").IsRequired();
            //Relations
            builder.HasOne(s => s.HallSegment)
               .WithMany(hs => hs.Seats)
               .HasForeignKey(s => s.HallSegmentId);
            //Table
            builder.ToTable("Seats");
        }
    }
}