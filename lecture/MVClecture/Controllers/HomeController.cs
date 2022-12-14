using MVClecture.Models;
using Microsoft.AspNetCore.Mvc;


// inherit from an abstract base controller so out controller inherits
//helpful methods for handling HTTP req/ res cycle
public class HomeController : Controller
{
    //attribute, http type & the route URL
    [HttpGet("")]
    public ViewResult Index()
    {
        //respond to request
        return View("Index");
    }
    [HttpGet("/videos")]
    // IActionResult can return a view or a redirect
    // easiest to default to IActionResult
    public IActionResult Videos()
    {
        // These ids from the end of youtube video URLs (was moved to VideoView Model)
        // List<string> youtubeVideoIds = new List<string>
        // {
        //     "dQw4w9WgXcQ", "fbqHK8i-HdA", "CUe2ymg1RHs", "-rEIOkGCbo8", "KYgZPphIKQY", "GPdGeLAprdg", "eg9_ymCEAF8", "nHkUMkUFuBc", "QTwcvNdMFMI", "j6YK-qgt_TI", "Wvjsgb2nB4o", "R_k4Sbf9gh8", "6avJHaC3C2U", "_mZBa3sqTrI", 
        // };

        VideosView videoViewModel = new VideosView();

        /*
        Each controller method / 'action' has it's own ViewBag that is
        SEPARATE, the data is not shared between them.

        The ViewBag properties are automatically available in the View
        that is returned from this method.
        */

        // ViewBag.YoutubeVideoIds = youtubeVideoIds;
        // ViewBag.Title = $"Here are {youtubeVideoIds.Count} of my favorite Videos";

        return View("Videos", videoViewModel);

    }

    //catch-all route
    [HttpGet("{**path}")]
    public IActionResult CatchAll()
    {
        //redirect relies on url/pathing
        // return Redirect("/");
        //redirectToAction relies on function name
        return RedirectToAction("Index");
    }
}