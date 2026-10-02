


using Microsoft.AspNetCore.Mvc;

public static class RegisterUsers
{
    public static IEndpointRouteBuilder MapRegisterUsers(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapPost("api/register/user/admin", async (RegisterReq newAdmin,[FromServices] RegisterHandler handleradmin) =>
        {
            var result= await handleradmin.HandleRegi(newAdmin);
            if (result.IsSuccessful == false)
            {
                
            return Results.BadRequest(result);
            }
            return Results.Ok(result);
        }).WithDisplayName("Admin");
        
        // users
        endpoint.MapPost("api/register/user", async () =>
        {
            return "cool user";
        });

        return endpoint;

    }
}