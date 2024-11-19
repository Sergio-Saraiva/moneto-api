using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moneto.Data.ModelsConfiguration.Base;
using Moneto.Domain.Entities;

namespace Moneto.Data.ModelsConfiguration;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
        builder.Property(x => x.PasswordHash).IsRequired();
        builder.Property(x => x.PasswordSalt).IsRequired();
        builder.HasMany(x =>  x.BankAccounts).WithOne(x => x.OwnerUser).HasForeignKey(x => x.OwnerUserId);
        builder.HasMany(x => x.Cards).WithOne(x => x.OwnerUser).HasForeignKey(x => x.OwnerUserId);
    }
}