

public static class MapTest
{
    public static void MapTestapi(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapGet("api/test", () =>
        {
            return "cool!";
        });
    }
}