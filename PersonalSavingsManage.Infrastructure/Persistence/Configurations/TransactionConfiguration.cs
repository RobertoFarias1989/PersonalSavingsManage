using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalSavingsManage.Core.Entities;

namespace PersonalSavingsManage.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : BaseEntityConfiguration<Transaction>
{
    public override void Configure(EntityTypeBuilder<Transaction> builder)
    {
        base.Configure(builder);

        builder
            .Property(t => t.Type)
            .HasConversion(typeof(string))
            .HasMaxLength(50);

        builder
            .Property(t => t.TransactionDate)
            .HasColumnName("TransactionDate");
    }
}
