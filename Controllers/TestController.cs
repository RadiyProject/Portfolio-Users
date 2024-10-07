using ASP.NET.Entities.Context;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TestController(ApplicationDbContext context, ILogger<TestController> logger) : Controller
{
    private readonly ApplicationDbContext _context = context;
    private readonly ILogger<TestController> _logger = logger;

    [HttpGet("")]
    public IActionResult TestGet()
    {
        return Ok("Good");
    }
}
