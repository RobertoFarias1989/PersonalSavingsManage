using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalSavingsManage.Core.Entities;

namespace PersonalSavingsManage.Infrastructure.Persistence.Configurations;

public class GoalConfiguration : BaseEntityConfiguration<Goal>
{
    public override void Configure(EntityTypeBuilder<Goal> builder)
    {
        base.Configure(builder);

        builder
            .Property(g => g.Title)
            .HasMaxLength(100);

        builder
            .Property(g => g.Deadline)
            .HasColumnName("Deadline");

        builder
            .Property(g => g.Status)
            .HasConversion(typeof(string))
            .HasMaxLength(50);

        builder
            .HasMany(g => g.Transactions)
            .WithOne(t => t.Goal)
            .HasForeignKey(t => t.IdGoal)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
