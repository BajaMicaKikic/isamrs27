using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mrs.ApplicationCore.Entities;

namespace mrs.Infrastructure.Data.Mapping
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            //Primary Key
            builder.HasKey(a => a.Id);
            //Properties
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("AccountId").IsRequired();
            builder.Property(a => a.AccountType).HasColumnName("AccountType").IsUnicode().IsRequired();
            //Table
            builder.ToTable("Accounts");
        }
    }
}
