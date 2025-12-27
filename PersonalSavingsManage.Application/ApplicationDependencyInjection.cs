using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PersonalSavingsManage.Application.FinancialGoal.Commands.CreateFinancialGoal;
using System.Reflection;

namespace PersonalSavingsManage.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddMediator()
            .AddValidator();

        return services;
    }

    public static IServiceCollection AddMediator( this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateGoalCommand));

        return services;
    }

    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();

        return services;
    }
}
