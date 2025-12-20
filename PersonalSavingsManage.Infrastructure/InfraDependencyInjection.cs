using Microsoft.Extensions.DependencyInjection;
using PersonalSavingsManage.Core.Repositories;
using PersonalSavingsManage.Infrastructure.Persistence.Repositories;

namespace PersonalSavingsManage.Infrastructure;

public static class InfraDependencyInjection
{
    public static IServiceCollection AddInfrastructure( this IServiceCollection services)
    {
        services.AddRepositories();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGoalRepository, GoalRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
