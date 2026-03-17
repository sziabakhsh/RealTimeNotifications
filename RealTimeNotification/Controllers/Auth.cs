using Microsoft.AspNetCore.Mvc;
using RealTimeNotification.Helpers;
using RealTimeNotification.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private static List<AppUser> users = new();

    private readonly JwtHelper _jwt;

    public AuthController(JwtHelper jwt)
    {
        _jwt = jwt;
    }

    [HttpPost("register")]
    public IActionResult Register(AppUser user)
    {
        users.Add(user);
        return Ok("User registered");
    }

    [HttpPost("login")]
    public IActionResult Login(AppUser user)
    {
        var existing = users.FirstOrDefault(x =>
            x.Username == user.Username &&
            x.Password == user.Password);

        if (existing == null)
            return Unauthorized();

        var token = _jwt.GenerateToken(user.Username);

        return Ok(new { token });
    }
}