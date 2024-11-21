using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Moneto.Data.ModelsConfiguration.Base;
using Moneto.Domain.Entities;

namespace Moneto.Data.ModelsConfiguration;

public class IncomeCategoryConfiguration : BaseEntityConfiguration<IncomeCategory>
{
    public override void Configure(EntityTypeBuilder<IncomeCategory> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description).IsRequired(false);
    }
}