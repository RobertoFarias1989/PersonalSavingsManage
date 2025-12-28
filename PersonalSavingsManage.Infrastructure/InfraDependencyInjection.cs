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
    public static IServiceCollection AddInfrastructure( this IServiceCollection services, IConfiguration configuration, IOptions<JwtOptions> options)
    {
        services.AddRepositories()
            .AddDatabase(configuration)
            .AddAuthService(configuration, options);
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

    public static IServiceCollection AddAuthService(this IServiceCollection services, IConfiguration configuration, IOptions<JwtOptions> options )
    {
        services.AddScoped<IAuthService, AuthService>();

        //services.AddOptions<JwtOptions>()
        //    .Bind(configuration.GetSection("Jwt"))
        //    .ValidateOnStart();

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
                    ValidIssuer = options.Value.Issuer,
                    ValidAudience = options.Value.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Key))
                };
            });

        return services;
    }
}
