

public static class Startup
{
    public static WebApplicationBuilder ConfigureAppServices(this WebApplicationBuilder builder)
    {
        builder.AppUi()
                .Validatejwtservice(builder.Configuration);
        builder.Services.Identitydependency();
        builder.Services.DbcontextDependency(builder.Configuration);
        builder.Services.AddScoped<RegisterHandler>();
        builder.Services.AddScoped<LoginHandlerservice>();
        builder.Services.AddScoped<UserHandler>();
        builder.Services.AddScoped<Generatejwt>();

        return builder;
    }

    public static WebApplication ConfigureAppPipline(this WebApplication app)
    {
        app.AppUiPipline();
        app.Validatejwtpipline();
        app.MapTestapi();
        app.MapRegisterUsers()
            .MapLoginEndpoint()
            .Mapuserendpoint();
       
        return app;
    }
}