

using Microsoft.AspNetCore.Identity;

public class LoginHandlerservice
{
    private readonly UserManager<AppUser> userManager;
    private readonly Generatejwt generatejwt;

    public LoginHandlerservice(UserManager<AppUser> userManager,Generatejwt generatejwt)
    {
        this.userManager = userManager;
        this.generatejwt = generatejwt;
    }
    
    public async Task<ApiResponse<object>> Login(Loginrequest req)
    {
        var user=await userManager.FindByEmailAsync(req.email);
        if(user is null)
        {
            return ApiResponse<object>.failed("pls sign up user doest not exist");
        }
        var validPassword=await userManager.CheckPasswordAsync(user,req.password);
        if (!validPassword)
        {
            return ApiResponse<object>.failed("incorrect password");
        }
        var roles=await userManager.GetRolesAsync(user);
        
        // token
        var token=await generatejwt.GenerateJwtservicesAsync(user);
        var res = new
        {
            token=token,
            user=user.Email,
            validfor="60min",
            roles=roles
        };
        return  ApiResponse<object>.Successful(res);
    }
}