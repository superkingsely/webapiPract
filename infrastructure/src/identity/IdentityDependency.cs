
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public static class IdentityDependency
{
    public static IServiceCollection Identitydependency(this IServiceCollection services)
    {
        services.AddIdentityCore<AppUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<Appdbcontext>();
        return services;
    }
}