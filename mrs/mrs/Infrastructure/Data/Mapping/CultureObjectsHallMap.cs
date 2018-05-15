namespace mrs.Infrastructure.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using mrs.ApplicationCore.Entities;
    public class CultureObjectHallMap : IEntityTypeConfiguration<CultureObjectHall>
    {
         
        public void Configure(EntityTypeBuilder<CultureObjectHall> builder)
        {
            //Primary Key
            builder.HasKey(coh => coh.Id);
            //Properties
            builder.Property(coh => coh.Id).ValueGeneratedOnAdd().HasColumnName("CultureObjectHallId").IsRequired();
            builder.Property(coh => coh.HallName).HasColumnName("CultureObjectHallName").IsUnicode().IsRequired();
            builder.Property(co => co.SeatsNo).HasColumnName("SeatsNumber").IsRequired();
            //Table
            builder.ToTable("CultureObjectHall");
        }
    }
}
