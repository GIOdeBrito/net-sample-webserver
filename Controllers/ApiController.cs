using System;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UserView.Models;

[Route("api")]
[ApiController]
public class ApiController : Controller
{
    [HttpGet("time")]
    public IActionResult GetTime ()
    {
        object json = new { action = "get_time", result = DateTime.UtcNow.ToString("HH:mm:ss") };
        return StatusCode(200, json);
    }

    [HttpGet("author")]
    public IActionResult GetAuthor ()
    {
        object json = new { action = "get_author", result = "Giordano de Brito" };
        return StatusCode(200, json);
    }

    [HttpPost("setuser")]
    public IActionResult SetCurrentUser ([FromBody] UserViewModel user)
    {
        UserViewModel itemUser = new UserViewModel(user.Name, user.Age);

        // Set data on current session
        HttpContext.Session.Set("CurrentUser", Encoding.UTF8.GetBytes(JsonSerializer.Serialize(itemUser)));
        
        object json = new { action = "set_user", result = "success" };
        return StatusCode(200, json);
    }
}