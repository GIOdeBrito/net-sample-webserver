using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UserView.Models;

public class HomeController : Controller
{
    public IActionResult Index ()
    {
        string userName = string.Empty;
        int userAge = 0;

        try
        {
            var data = HttpContext.Session.Get("CurrentUser");
            var json = Encoding.UTF8.GetString(data);
            var userData = JsonSerializer.Deserialize<UserViewModel>(json);

            userAge = userData.Age;
            userName = userData.Name;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());

            DateTime birthtime = new DateTime(2001, 11, 19);
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            // My current age
            userAge = (int) (today - birthtime).Days / 365;
            userName = "Giordano";
        }

        UserViewModel obj = new UserViewModel(userName, userAge);

        //object obj = new { Name = userName, Age = userAge };
        return View(obj);
    }
}