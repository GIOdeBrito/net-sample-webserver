using Microsoft.AspNetCore.Mvc;

public class NotFoundController : Controller
{
    public IActionResult PageNotFound ()
    {
        return View("NotFound");
    }
}