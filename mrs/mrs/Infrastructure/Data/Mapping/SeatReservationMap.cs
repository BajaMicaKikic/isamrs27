namespace mrs.Infrastructure.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using mrs.ApplicationCore.Entities;
    public class SeatReservationMap : IEntityTypeConfiguration<SeatReservation>
    {
        public void Configure(EntityTypeBuilder<SeatReservation> builder)
        {
            // Primary Key
            builder.HasKey(sr => sr.Id);
            // Properties
            builder.Property(sr => sr.Id).ValueGeneratedOnAdd().HasColumnName("SeatReservationId").IsRequired();
            builder.Property(sr => sr.IsReserved).HasColumnName("IsReserved").IsRequired();
            builder.Property(sr => sr.IsActive).HasColumnName("IsActive").IsRequired();
            builder.Property(sr => sr.IsPaid).HasColumnName("IsPaid").IsRequired();
            builder.Property(sr => sr.ScreeningId).HasColumnName("ScreeningId").IsRequired();
            builder.Property(sr => sr.SeatId).HasColumnName("SeatId").IsRequired();
            //Relations
            builder.HasOne(sr => sr.Screening)
               .WithMany(s => s.SeatReservations)
               .HasForeignKey(sr => sr.ScreeningId);

            builder.HasOne(sr => sr.Seat)
                .WithMany(s => s.SeatReservations)
                .HasForeignKey(sr => sr.SeatId);
            //Table
            builder.ToTable("SeatReservation");
        }
    }
}

