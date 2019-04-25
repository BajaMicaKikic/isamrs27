namespace mrs.Infrastructure.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using mrs.ApplicationCore.Entities;
    public class RemarkMap : IEntityTypeConfiguration<Remark>
    {
        public void Configure(EntityTypeBuilder<Remark> builder)
        {
            // Primary Key
            builder.HasKey(r => r.Id);
            // Properties
            builder.Property(r => r.Id).ValueGeneratedOnAdd().HasColumnName("RemarkId").IsRequired();
            builder.Property(r => r.CultureObjectId).HasColumnName("CultureObjectId").IsRequired();
            builder.Property(r => r.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(r => r.Grade).HasColumnName("Grade").IsRequired();
            //Relations
            builder.HasOne(r => r.CultureObject)
               .WithMany( co => co.Remarks)
               .HasForeignKey(ci => ci.CultureObjectId);

            builder.HasOne(r => r.User)
                .WithMany( u => u.Remarks)
                .HasForeignKey(ci => ci.UserId);
            //Table
            builder.ToTable("Remarks");
        }
    }
}
