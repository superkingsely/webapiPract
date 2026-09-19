

public static class Appui
{
    public static WebApplicationBuilder configureuiservice(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }
    public static WebApplication configureuipipline(this WebApplication app)
    {

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
    {
        // Points Swagger to the underlying OpenAPI JSON document
        options.SwaggerEndpoint("/openapi/v1.json", "My API v1");
    });
            
        }
        return app;
    }
}