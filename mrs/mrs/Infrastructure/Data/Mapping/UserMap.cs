using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mrs.ApplicationCore.Entities;

namespace mrs.Infrastructure.Data.Mapping
{

    /// <summary>
    /// Class that represents configurations for entity User.
    /// </summary>
    public class UserMap : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary Key
            builder.HasKey(u => u.Id);
            // Properties
            builder.Property(u => u.Id).ValueGeneratedOnAdd().HasColumnName("UserId").IsRequired();
            builder.Property(u => u.FirstName).HasColumnName("FirstName").IsUnicode().IsRequired();
            builder.Property(u => u.LastName).HasColumnName("LastName").IsUnicode().IsRequired();
            builder.Property(u => u.EmailAddress).HasColumnName("Email").IsRequired();
            // Table Name
            builder.ToTable("Users");
        }
    }
}