using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moneto.Data.ModelsConfiguration.Base;
using Moneto.Domain.Entities;

namespace Moneto.Data.ModelsConfiguration;

public class BankAccountConfiguration : BaseEntityConfiguration<BankAccount>
{
    public override void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Bank).IsRequired();
        builder.HasOne(x => x.OwnerUser).WithMany(x => x.BankAccounts).HasForeignKey(x => x.OwnerUserId);
    }
}