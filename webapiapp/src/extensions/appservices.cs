
public static class Appservices
{
    public static WebApplicationBuilder configureappserviceservice(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        return builder;
    }
    public static WebApplication configureappservicepipline(this WebApplication app)
    {
        app.MapControllers();
        return app;
    }
}