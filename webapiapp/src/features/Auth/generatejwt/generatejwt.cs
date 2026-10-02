

// di addscope
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

public  class Generatejwt
{
    private readonly IConfiguration configuration;
    private readonly UserManager<AppUser> userManager;

    public Generatejwt(IConfiguration configuration, UserManager<AppUser> userManager)
    {
        this.configuration = configuration;
        this.userManager = userManager;
    }
    public async Task< string> GenerateJwtservicesAsync(AppUser user)
    {
        var key= new SymmetricSecurityKey( Encoding.UTF8.GetBytes(configuration["jwt:secretkey"]!) );
        var credential=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
        var roles=await userManager.GetRolesAsync(user);
        var claims= new List<Claim>
        {
            new("id",user.Id),
            new(ClaimTypes.Email,user.Email!)
           
        };
        foreach(var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role,role));
        }
        var expire=configuration["jwt:expirationmin"];
        var expireat=DateTime.UtcNow.AddMinutes(double.Parse(expire));

        var token=new JwtSecurityToken(
            issuer:configuration["jwt:issuer"],
            audience:configuration["jwt:audience"],
            claims:claims,
            expires:expireat,
            signingCredentials:credential
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}