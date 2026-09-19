


using Microsoft.EntityFrameworkCore;

public class AppDbContext:DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
    {
        
    }

    public DbSet<Users> Users {get;set;}

}