using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    //attribute, http type & the route URL
    [HttpGet("")]
    public ViewResult Index()
    {
        //respond to request
        return View("Index");
    }
}