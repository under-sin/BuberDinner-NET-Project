using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // configurando dependencia do MediatR
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        
        return services;
    }
}