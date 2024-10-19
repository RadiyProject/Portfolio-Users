using Microsoft.EntityFrameworkCore;
namespace Users.Entities.Context;
public static class DataExtensions
{
    public static WebApplication ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();
        return app;
    }
}