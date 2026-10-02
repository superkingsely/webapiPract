

using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

public static class Appui
{
    public static WebApplicationBuilder AppUi(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt =>
        {
            AddAuthbtn(opt);
        });

        return builder;
    }

    private static void AddAuthbtn(SwaggerGenOptions options)
    {
        options.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
        {
            Name="Authorization",
            Description="pls paste ur token here",
            In=ParameterLocation.Header,
            Type=SecuritySchemeType.Http,
            Scheme="bearer",
            BearerFormat="JWT"
        });
        options.AddSecurityRequirement(docs => new OpenApiSecurityRequirement
        {
            [
                    new OpenApiSecuritySchemeReference(
                        "Bearer",
                        docs)
                ] = []
        }
       );
    }

    public static WebApplication AppUiPipline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(options=>options.SwaggerEndpoint("/swagger/v1/swagger.json","Test api"));
            
        }
        return app;
    }
}