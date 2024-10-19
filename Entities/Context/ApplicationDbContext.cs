using Microsoft.EntityFrameworkCore;

namespace Users.Entities.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
}