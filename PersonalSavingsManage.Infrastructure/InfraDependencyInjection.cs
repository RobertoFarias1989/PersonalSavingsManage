using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonalSavingsManage.Core.Repositories;
using PersonalSavingsManage.Core.Services;
using PersonalSavingsManage.Infrastructure.Auth;
using PersonalSavingsManage.Infrastructure.Persistence;
using PersonalSavingsManage.Infrastructure.Persistence.Repositories;
using PersonalSavingsManage.Infrastructure.Settings;
using System.Text;

namespace PersonalSavingsManage.Infrastructure;

public static class InfraDependencyInjection
{
    public static IServiceCollection AddInfrastructure( this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories()
            .AddDatabase(configuration)
            .AddAuthService(configuration);
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

    public static IServiceCollection AddAuthService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthService, AuthService>();

        services.AddOptions<JwtOptions>()
            .Bind(configuration.GetSection("Jwt"))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var jwt = configuration.GetSection("Jwt").Get<JwtOptions>() 
            ?? throw new InvalidOperationException("Falta a configuração do Jwt.");

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwt.Issuer,
                    ValidAudience = jwt.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key))
                };
            });

        return services;
    }
}
