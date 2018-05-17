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
            builder.Property(coh => coh.CultureObjectId).HasColumnName("CultureObjectId").IsRequired();
            builder.Property(coh => coh.HallName).HasColumnName("CultureObjectHallName").IsUnicode().IsRequired();
            builder.Property(coh => coh.SeatsNo).HasColumnName("SeatsNumber").IsRequired();
            //Relations
            builder.HasOne(coh => coh.CultureObject)
               .WithMany(co => co.CultureObjectHalls)
               .HasForeignKey(coh => coh.CultureObjectId);
            //Table
            builder.ToTable("CultureObjectHall");
        }
    }
}
