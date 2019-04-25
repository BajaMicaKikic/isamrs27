namespace mrs.Infrastructure.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using mrs.ApplicationCore.Entities;

    public class CultureObjectMap : IEntityTypeConfiguration<CultureObject>
    {
        public void Configure(EntityTypeBuilder<CultureObject> builder)
        {
            //Primary Key
            builder.HasKey(co => co.Id);
            //Properties
            builder.Property(co => co.Id).ValueGeneratedOnAdd().HasColumnName("CultureObjectId").IsRequired();
            builder.Property(co => co.Name).HasColumnName("CultureObjectName").IsUnicode().IsRequired();
            builder.Property(co => co.Address).HasColumnName("CultureObjectAddress").IsRequired();
            builder.Property(co => co.PromoDescription).HasColumnName("CultureObjectPromoDesc").IsRequired();
            builder.Property(co => co.ObjectDiscriminator).HasColumnName("CultureObjectType").IsRequired();
            //Table
            builder.ToTable("CultureObjects");
        }
    }
}
