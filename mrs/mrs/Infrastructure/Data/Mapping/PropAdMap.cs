namespace mrs.Infrastructure.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using mrs.ApplicationCore.Entities;
    public class PropAdMap : IEntityTypeConfiguration<PropAd>
    {
        public void Configure(EntityTypeBuilder<PropAd> builder)
        {
            // Primary Key
            builder.HasKey(p => p.Id);
            // Properties
            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnName("PropId").IsRequired();
            builder.Property(p => p.ThematicPropId).HasColumnName("ThematicPropId").IsRequired();
            builder.Property(p => p.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(p => p.PropPrice).HasColumnName("PropPrice").IsRequired();
            builder.Property(p => p.PropDescription).HasColumnName("PropDescription").IsRequired();
            builder.Property(p => p.EndBidDate).HasColumnName("EndBidDate").IsRequired();
            builder.Property(p => p.UserReservedId).HasColumnName("UserReserveId");
            //Relations
            builder.HasOne(p => p.User)
               .WithMany(u => u.PropAds)
               .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.UserReserved)
                .WithMany(u => u.ReservedAds)
                .HasForeignKey(p => p.UserReservedId);

            builder.HasOne(p => p.ThematicProp)
                .WithMany(t => t.PropAds)
                .HasForeignKey(p => p.ThematicPropId);
            //Table
            builder.ToTable("PropAds");
        }
    }
}
