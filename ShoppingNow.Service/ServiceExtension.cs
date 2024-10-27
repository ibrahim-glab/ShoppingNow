using Microsoft.Extensions.DependencyInjection;
using ShoppingNow.Service.Interfaces;
using ShoppingNow.Service.Services;

namespace ShoppingNow.Service;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserServices>();
        serviceCollection.AddScoped<IEmail, Email>();
        return serviceCollection;
    }
}