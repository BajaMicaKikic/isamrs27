namespace mrs.Infrastructure.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using mrs.ApplicationCore.Entities;
    public class ThematicPropMap : IEntityTypeConfiguration<ThematicProp>
    {
        public void Configure(EntityTypeBuilder<ThematicProp> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);
            // Properties
            builder.Property(t => t.Id).ValueGeneratedOnAdd().HasColumnName("ThematicPropId").IsRequired();
            builder.Property(t => t.PropName).HasColumnName("PropName").IsRequired();
            //Table
            builder.ToTable("ThematicProps");
        }
    }
}
