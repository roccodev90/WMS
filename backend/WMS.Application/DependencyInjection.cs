using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WMS.Application.Common.Behaviors;

namespace WMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ApplicationAssemblyMarker).Assembly);
        services.AddMediatR(typeof(ApplicationAssemblyMarker).Assembly);
        services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyMarker).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}
