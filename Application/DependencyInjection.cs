using Application.Common.Behaviors;
using Application.Core.Authentication.Commands.Register;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssemblyContaining<RegisterCommandValidator>();
        services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));
        return services;
    }
}
