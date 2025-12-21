using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalSavingsManage.Core.Entities;

namespace PersonalSavingsManage.Infrastructure.Persistence.Configurations;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder
            .OwnsOne(u => u.Address)
            .Property(a => a.Street)
            .HasColumnName("Street")
            .HasMaxLength(100);

        builder
            .OwnsOne(u => u.Address)
            .Property(a => a.City)
            .HasColumnName("City")
            .HasMaxLength(100);

        builder
           .OwnsOne(u => u.Address)
           .Property(a => a.State)
           .HasColumnName("State")
           .HasMaxLength(100);

        builder
           .OwnsOne(u => u.Address)
           .Property(a => a.PostalCode)
           .HasColumnName("PostalCode")
           .HasMaxLength(100);

        builder
            .OwnsOne(u => u.Address)
            .Property(a => a.Country)
            .HasColumnName("Country")
            .HasMaxLength(100);

        builder
            .OwnsOne(u => u.Email,
            email =>
            {
                email.HasIndex(e => e.EmailAddress)
                .IsUnique();
            });

        builder
            .OwnsOne(u => u.Name)
            .Property(n => n.FullName)
            .HasColumnName("FullName")
            .HasMaxLength(150);

        builder
            .OwnsOne(u => u.Password)
            .Property(p => p.PasswordValue)
            .HasColumnName("Password")
            .HasMaxLength (150);

        builder
            .Property(u => u.Role)
            .HasMaxLength(100);

        builder
            .HasMany(u => u.Goals)
            .WithOne(g => g.User)
            .HasForeignKey(g => g.IdUser)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(u => u.Transactions)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
