using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalSavingsManage.Core.Repositories;
using PersonalSavingsManage.Infrastructure.Persistence;
using PersonalSavingsManage.Infrastructure.Persistence.Repositories;

namespace PersonalSavingsManage.Infrastructure;

public static class InfraDependencyInjection
{
    public static IServiceCollection AddInfrastructure( this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddDatabase(configuration);
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGoalRepository, GoalRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PersonalSavingsCs");

        services.AddDbContext<PersonalSavingsDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}
