using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moneto.Data.ModelsConfiguration.Base;
using Moneto.Domain.Entities;

namespace Moneto.Data.ModelsConfiguration;

public class CardConfiguration : BaseEntityConfiguration<Card>
{
    public override void Configure(EntityTypeBuilder<Card> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Limit).IsRequired();
        builder.Property(x => x.Network).IsRequired();
        builder.Property(x => x.IsCredit).IsRequired();
        builder.Property(x => x.IsDebit).IsRequired();
        builder.Property(x => x.IsVirtual).IsRequired();
        builder.HasOne(x => x.OwnerUser).WithMany(x => x.Cards).HasForeignKey(x => x.OwnerUserId);    
        builder.HasOne(x => x.BankAccount).WithMany(x => x.Cards).HasForeignKey(x => x.BankAccountId);
    }
}