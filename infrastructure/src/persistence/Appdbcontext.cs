

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class Appdbcontext:IdentityDbContext<AppUser>
{
    public Appdbcontext(DbContextOptions<Appdbcontext> option) : base(option)
    {
        
    }
    public DbSet<AppUser> Users {get;set;}
}