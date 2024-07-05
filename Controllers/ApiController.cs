using System;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UserView.Models;
//using ZipHelper.Create;

[Route("api/v1")]
public class ApiController : Controller
{
    [HttpGet("version")]
    public IActionResult GetVersion ()
    {
        object json = new { action = "version", result = "V1" };
        return StatusCode(200, json);
    }
    
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

    /*[HttpGet("downloadprojectxml/{filename}")]
    public IActionResult GetFile (string filename)
    {
        
        
        return File();
    }*/
}

[Route("api/v2")]
public class ApiControllerV2 : Controller
{
    [HttpGet("version")]
    public IActionResult GetVersion ()
    {
        object json = new { action = "version", result = "V2" };
        return StatusCode(200, json);
    }

    [HttpPost("setuser")]
    public IActionResult SetCurrentUser ([FromBody] UserViewModel user)
    {
        UserViewModel itemUser = new UserViewModel(user.Name, user.Age);

        try
        {
            // Set data on current session
            HttpContext.Session.Set("CurrentUser", Encoding.UTF8.GetBytes(JsonSerializer.Serialize(itemUser)));
            
            object json = new { action = "set_user", result = "success" };
            return StatusCode(200, json);
        }
        catch(Exception ex)
        {
            object json = new { action = "set_user", error = ex.Message };
            return StatusCode(500, json);
        }
    }
}