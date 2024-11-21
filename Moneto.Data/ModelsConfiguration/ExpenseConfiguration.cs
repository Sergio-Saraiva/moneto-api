using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moneto.Data.ModelsConfiguration.Base;
using Moneto.Domain.Entities;

namespace Moneto.Data.ModelsConfiguration;

public class ExpenseConfiguration : BaseEntityConfiguration<Expense>
{
    public override void Configure(EntityTypeBuilder<Expense> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Description).IsRequired(false);
        builder.Property(x => x.Value).IsRequired();
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.IsPix).IsRequired().HasDefaultValue(false).IsRequired();
        builder.Property(x => x.IsFromCard).IsRequired().HasDefaultValue(false).IsRequired();
        builder.Property(x => x.IsDebit).IsRequired().HasDefaultValue(false).IsRequired();
        builder.Property(x => x.IsCredit).IsRequired().HasDefaultValue(false).IsRequired();
        builder.HasOne(x => x.Category).WithMany(x => x.Expenses).HasForeignKey(x => x.ExpenseCategoryId).IsRequired(false);
        builder.HasOne(x => x.Card).WithMany(x => x.Expenses).HasForeignKey(x => x.CardId).IsRequired(false);
        builder.HasOne(x => x.ExpenseOwner).WithMany(x => x.Expenses).HasForeignKey(x => x.ExpenseOwnerId);
    }
}