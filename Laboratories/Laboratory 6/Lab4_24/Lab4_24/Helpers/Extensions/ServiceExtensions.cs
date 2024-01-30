using Lab4_24.Models;
using Lab4_24.Repositories.UserRepository;
using Lab4_24.Services.UserService;

namespace Lab4_24.Helpers.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        return services;
    }
}