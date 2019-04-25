namespace mrs.Infrastructure.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using mrs.ApplicationCore.Entities;
    public class HallSegmentMap : IEntityTypeConfiguration<HallSegment>
    {

        public void Configure(EntityTypeBuilder<HallSegment> builder)
        {
            //Primary Key
            builder.HasKey(hs => hs.Id);
            //Properties
            builder.Property(hs => hs.Id).ValueGeneratedOnAdd().HasColumnName("HallSegmentId").IsRequired();
            builder.Property(hs => hs.HallSegmentName).HasColumnName("HallSegmentName").IsUnicode().IsRequired();
            builder.Property(hs => hs.IsOpen).HasColumnName("IsOpen").IsRequired();
            builder.Property(hs => hs.SeatsNo).HasColumnName("SeatsNo").IsRequired();

            //Table
            builder.ToTable("HallSegment");
        }
    }
}
