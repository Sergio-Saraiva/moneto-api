using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moneto.Data.ModelsConfiguration.Base;
using Moneto.Domain.Entities;

namespace Moneto.Data.ModelsConfiguration;

public class IncomeConfiguration : BaseEntityConfiguration<Income>
{
    public override void Configure(EntityTypeBuilder<Income> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Description).IsRequired(false);
        builder.Property(x => x.Value).IsRequired();
        builder.Property(x => x.Date).IsRequired();
        builder.HasOne(x => x.Category).WithMany(x => x.Incomes).HasForeignKey(x => x.IncomeCategoryId);
    }
}