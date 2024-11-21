using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moneto.Data.ModelsConfiguration.Base;
using Moneto.Domain.Entities;

namespace Moneto.Data.ModelsConfiguration;

public class ExpenseOwnerConfiguration : BaseEntityConfiguration<ExpenseOwner>
{
    public override void Configure(EntityTypeBuilder<ExpenseOwner> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Email).IsRequired(false);
        builder.Property(x => x.PhoneNumber).IsRequired(false);
        builder.HasMany(x => x.Expenses).WithOne(x => x.ExpenseOwner).HasForeignKey(x => x.ExpenseOwnerId);
    }
}