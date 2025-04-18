using projectQuotes.Application.Repositories.Shared;
using projectQuotes.Constants.Shared;
using projectQuotes.EfPersistence.Data;
using projectQuotes.EfPersistence.Repositories;
using projectQuotes.Infrastructure.JwtTokenFactories;
using Microsoft.EntityFrameworkCore;
using Scrutor;
using projectQuotes.Application.Repositories.Shared.Relation;
using projectQuotes.Infrastructure.LinkFactories;
using Npgsql;
using projectQuotesWebApi.Application.Services.Shared;
using projectQuotesWebApi.Application.Services.Shared.Relation;

namespace projectQuotesWebApi.Extensions;

public static class DependencyInjectionExtensions
{

    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(AppSettingsStringConstants.DefaultConnection);

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

        var dataSource = dataSourceBuilder.Build();
        services.AddDbContext<AppDbContext>(options =>
        {
            options
                .UseNpgsql(dataSource)
                .UseLazyLoadingProxies();
        });




        services.Scan(scan =>
            scan.FromAssembliesOf([
                typeof(ICrudRepository<>),
                typeof(CrudRepository<>),
                typeof(ICrudService<,,,,>),
                typeof(CrudService<,,,,,>)
            ])
            .AddClasses(x => x.AssignableTo(typeof(ICrudRepository<>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithScopedLifetime()
            .AddClasses(x => x.AssignableTo(typeof(ICrudService<,,,,>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithScopedLifetime()
            );

        services.Scan(scan =>
            scan.FromAssembliesOf([
                typeof(IRelationRepository<,,>),
                typeof(RelationRepository<,,>),
                typeof(IRelationService<,,>),
                typeof(RelationService<,,,>)
            ])
            .AddClasses(x => x.AssignableTo(typeof(IRelationRepository<,,>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithScopedLifetime()
            .AddClasses(x => x.AssignableTo(typeof(IRelationService<,,>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithScopedLifetime()

            );




        services.AddScoped<IJwtTokenFactory, JwtTokenFactory>();


        services.AddScoped<ILinkFactory, LinkFactory>();





    }
}
