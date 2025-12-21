using Microsoft.EntityFrameworkCore;
using PersonalSavingsManage.Core.Entities;
using System.Reflection;

namespace PersonalSavingsManage.Infrastructure.Persistence;

public class PersonalSavingsDbContext : DbContext
{
    public PersonalSavingsDbContext(DbContextOptions<PersonalSavingsDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
