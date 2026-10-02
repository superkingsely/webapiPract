

// di addscope
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public  class Generatejwt
{
    private readonly IConfiguration configuration;

    public Generatejwt(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public async Task< string> GenerateJwtservicesAsync(AppUser user)
    {
        var key= new SymmetricSecurityKey( Encoding.UTF8.GetBytes(configuration["jwt:secretkey"]!) );
        var credential=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
        
        var claims= new List<Claim>
        {
            new("id",user.Id),
            new("email",user.Email!)
        };
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