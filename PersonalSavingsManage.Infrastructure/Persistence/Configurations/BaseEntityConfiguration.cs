using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalSavingsManage.Core.Entities;

namespace PersonalSavingsManage.Infrastructure.Persistence.Configurations;

public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder
            .HasKey(b => b.Id);

        builder
            .Property(b => b.CreatedAt)
            .HasColumnName("datetime");

        builder
            .Property(b => b.UpdatedAt)
            .HasColumnName("datetime");
    }
}
