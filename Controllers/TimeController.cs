using Microsoft.AspNetCore.Mvc;

public class TimeController : Controller
{
    public IActionResult GetTime ()
    {
        var json = new { action = "get_time", result = DateTime.UtcNow.ToString("HH:mm:ss") };
        return StatusCode(200, json);
    }
}