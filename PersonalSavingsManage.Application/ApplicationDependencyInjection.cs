using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PersonalSavingsManage.Application.FinancialGoal.Commands.CreateFinancialGoal;
using System.Reflection;

namespace PersonalSavingsManage.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator()
            .AddValidator();

        return services;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateFinancialGoalCommand));

        return services;
    }

    private static IServiceCollection AddValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
