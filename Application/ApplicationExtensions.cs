using Application.UseCases;
using Domain.Interfaces.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IPersonUseCase, PersonUseCase>();
        return services;
    }
}
