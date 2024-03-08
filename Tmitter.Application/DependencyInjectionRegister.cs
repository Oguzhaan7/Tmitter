using System.Reflection;
using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Tmitter.Application.Common.Behaviors;

namespace Tmitter.Application;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var mapsterConfig = TypeAdapterConfig.GlobalSettings;
        mapsterConfig.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(mapsterConfig);
        services.AddScoped<IMapper, ServiceMapper>();

        services.AddMediatR(config => { config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}