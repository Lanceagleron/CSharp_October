using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }
    

     // remember to use [HttpPost] attributes!
    [HttpPost("/submit")]
    
    public IActionResult Submit(string username, string location, string language, string comment)
    {
        // Do something with form input
        ViewBag.username = username;
        ViewBag.location = location;
        ViewBag.language = language;
        ViewBag.comment = comment;

        return View("GotInfo");
    }
}