

using Microsoft.EntityFrameworkCore;

public static class Appdb{
    public static WebApplicationBuilder Appdbconfig(this WebApplicationBuilder builder){

        builder.Services.AddDbContext<AppDbContext>( option=>option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")) );

        return builder;
        
    }
}