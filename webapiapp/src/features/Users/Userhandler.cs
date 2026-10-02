

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UserHandler
{
    private readonly UserManager<AppUser> userManager;
    private readonly Appdbcontext context;

    public UserHandler(UserManager<AppUser> userManager ,Appdbcontext context)
    {
        this.userManager = userManager;
        this.context = context;
    }

    public async Task<ApiResponse<List<AppUser>>> GetUsers()
    {
        var users=await context.Users.ToListAsync();
        var res=ApiResponse<List<AppUser>>.Successful(users);
        return res ;
    }
    public async Task<ApiResponse<AppUser>> RemoveUser(string id)
    {
        var user=await context.Users.FirstOrDefaultAsync(u=>u.Id==id);
        if(user is null)
        {
        return ApiResponse<AppUser>.failed("user does not excess!!");
            
        }
         context.Remove(user);
         await context.SaveChangesAsync();
        var res=ApiResponse<AppUser>.Successful(user);
        return res ;
    }
}