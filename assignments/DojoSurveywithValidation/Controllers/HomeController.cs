using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        // User user = new User();

        return View("Index");
    }
    

     // remember to use [HttpPost] attributes!
    [HttpPost("/submit")]
    
    public IActionResult  Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            
            return View("GotInfo", newUser);
        }
        return View("Index");
    }
}
    