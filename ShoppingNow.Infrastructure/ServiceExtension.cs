using Microsoft.Extensions.DependencyInjection;
using ShoppingNow.core.Contracts;
using ShoppingNow.Infrastructure.Repositories;

namespace ShoppingNow.Infrastructure;

public static class ServiceExtension
{

    public static IServiceCollection AddDataLayerServices(this IServiceCollection service)
    {
        service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        return service;
    }
}