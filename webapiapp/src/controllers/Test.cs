

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class Test : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "okay";
    }
}