

using Microsoft.AspNetCore.Mvc;

public static class UsersEndpoint
{
    public static IEndpointRouteBuilder Mapuserendpoint(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapGet("api/users", async ([FromServices] UserHandler userHandler ) =>
        {
            var res=userHandler.GetUsers();
            if(res is null)
            {
                return Results.BadRequest(new{message="oh oh endpoint return error pls try again or call cj for help"});
            }
            return Results.Ok(res) ;
        }).RequireAuthorization();

        endpoint.MapGet("api/user/delete", async ([FromServices] UserHandler userHandler,[FromQuery] string id ) =>
        {
            var res=userHandler.RemoveUser(id);
            if(res is null)
            {
                return Results.BadRequest(new{message="oh oh endpoint return error pls try again or call cj for help"});
            }
            return Results.Ok(res) ;
        });
        return endpoint;
    }
}