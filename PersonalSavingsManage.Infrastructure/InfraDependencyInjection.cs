using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using PersonalSavingsManage.Core.Repositories;
using PersonalSavingsManage.Infrastructure.Persistence;
using PersonalSavingsManage.Infrastructure.Persistence.Repositories;

namespace PersonalSavingsManage.Infrastructure;

public static class InfraDependencyInjection
{
    public static IServiceCollection AddInfrastructure( this IServiceCollection services)
    {
        services.AddMongo()
            .AddRepositories();
        return services;
    }
    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
        services.AddSingleton(s =>
        {
            var configuration = s.GetService<IConfiguration>();
            var options = new MongoDbOptions();

            configuration!.GetSection("Mongo").Bind(options);

            return options;
        });

        services.AddSingleton<IMongoClient>(sp =>
        {
            var options = sp.GetService<MongoDbOptions>();

            return new MongoClient(options!.ConnectionString);
        });

        services.AddTransient(sp =>
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            var options = sp.GetService<MongoDbOptions>();
            var mongoClient = sp.GetService<IMongoClient>();

            return mongoClient!.GetDatabase(options!.Database);
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IFinancialGoalRepository, FinancialGoalRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
