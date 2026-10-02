

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

public static class Validatejwt
{
    public static WebApplicationBuilder Validatejwtservice(this WebApplicationBuilder builder,IConfiguration configuration)
    {
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(option =>
                        {
                            option.TokenValidationParameters=new TokenValidationParameters
                            {
                                ValidateIssuer=true,
                                ValidateAudience=true,
                                ValidateIssuerSigningKey=true,
                                ValidateLifetime=true,
                                ClockSkew=TimeSpan.Zero,
                                ValidIssuer=configuration["jwt:issuer"],
                                ValidAudience=configuration["jwt:audience"],
                                IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:secretkey"]!))
                            };
                        });
        builder.Services.AddAuthorization();
                        
        return builder;
    }
    public static WebApplication Validatejwtpipline(this WebApplication app)
    {
        app.UseAuthentication()
            .UseAuthorization();
        return app;
    }
}