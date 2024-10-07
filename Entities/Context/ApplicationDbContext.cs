using Microsoft.EntityFrameworkCore;

namespace ASP.NET.Entities.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
}