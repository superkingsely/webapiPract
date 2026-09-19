


public static class Startup
{
    public static WebApplicationBuilder configureservice(this WebApplicationBuilder builder)
    {
        builder.configureuiservice();
        builder.configureappserviceservice();
        builder.Appdbconfig();

        return builder;
    }
    public static WebApplication configurepipline(this WebApplication app)
    {
        app.configureuipipline();
        app.configureappservicepipline();

        return app;
    }
}