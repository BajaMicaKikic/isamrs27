using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mrs.ApplicationCore.Entities;


namespace mrs.Infrastructure.Data.Mapping
{
    public class ActorMap : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            //Primary Key
            builder.HasKey(a => a.Id);
            //Properties
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("ActorId").IsRequired();
            builder.Property(a => a.FirstName).HasColumnName("ActorFirsName").IsUnicode().IsRequired();
            builder.Property(a => a.LastName).HasColumnName("ActorLastName").IsRequired();
            //Table
            builder.ToTable("Actors");
        }
    }
}
