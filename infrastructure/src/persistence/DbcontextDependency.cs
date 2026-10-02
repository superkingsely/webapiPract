
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Dbcontextdependency
{
    public static IServiceCollection DbcontextDependency(this IServiceCollection services,IConfiguration config)
    {
        services.AddDbContext<Appdbcontext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        return services;
    }
}