

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext context;

    public UserController(AppDbContext context)
    {
        this.context = context;
    }
    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser([FromBody]CreateUsersDto newuser)
    {

        var user= new Users()
        {
            Name=newuser.Name,
            Email=newuser.Email
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        var res = new
        {
            message="created",
            data=newuser
        };

        return Ok(res);
    }

    [HttpGet("all-users")]
    public async Task<IActionResult> Getusers()
    {
       var Users= await context.Users.ToListAsync();

       return Ok(Users);
    }
}