

using Microsoft.AspNetCore.Mvc;

public static class LoginEndpoint
{
    public static IEndpointRouteBuilder MapLoginEndpoint(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapPost("api/login/user", async ([FromBody] Loginrequest req,[FromKeyedServices] LoginHandlerservice loginhandler ) =>
        {
            return loginhandler.Login(req);
        });
        return endpoint;
    }
}