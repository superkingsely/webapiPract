

using Microsoft.AspNetCore.Identity;

public class RegisterHandler
{
    private readonly UserManager<AppUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public RegisterHandler(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    public async Task<ApiResponse<object>> HandleRegi(RegisterReq newadmin)
    {
        var input = string.IsNullOrWhiteSpace(newadmin.Email);
        if (input)
        {
            return ApiResponse<object>.failed("pls no leave any space and be sure to enter ur details properly");
        }
        var existingUser = await userManager.FindByEmailAsync(newadmin.Email);

        if (existingUser is not null)
        {
            return ApiResponse<object>.failed("Admin already exist");
        }

        var admin = new AppUser
        {
            UserName = newadmin.Email,
            Email = newadmin.Email,
            EmailConfirmed = true
        };
        var isrolecreated = await roleManager.FindByNameAsync("Admin");
        if (isrolecreated.Name != "Admin")
        {
            var role = new IdentityRole
            {
                Name = "Admin"
            };
            var createadminrole = await roleManager.CreateAsync(role);
            Console.WriteLine("yeah only one admin role that can be created");
        }
        var isadmin= await userManager.GetUsersInRoleAsync("Admin");
        if (isadmin.Any())
        {
            return ApiResponse<object>.failed("we already hv an admin cant create two");

        }
        // create admin
        var result = await userManager.CreateAsync(admin, newadmin.Password);
        if (!result.Succeeded)
        {
            return ApiResponse<object>.failed("reg error pls retry");

        }
        // var role= await userManager.rol
        var roleresult = await userManager.AddToRoleAsync(admin, "Admin");
        if (!roleresult.Succeeded)
        {
            return ApiResponse<object>.failed("hmmm cant be assign a role pls try again!! ");

        }

        var res = new
        {
            message = "admin successfully registered!!!!"
        };
        return ApiResponse<object>.Successful(res);
    }

}