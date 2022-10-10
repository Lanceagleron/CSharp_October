using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        int? check = HttpContext.Session.GetInt32("Counter");
            System.Console.WriteLine(check);
            if (check == null)
            {
            HttpContext.Session.SetInt32("Counter",(int)0);   
            }
            TempData["count"] = HttpContext.Session.GetInt32("Counter");
            return View();
    }

    [HttpPost("Generate")]
        
    public IActionResult Generate()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string passcode = "";
        Random rand = new Random();
        for( int i = 1; i < 15; i++)
        {
            int x = rand.Next(0,36);
            passcode += chars[x];
        }
        TempData["passcode"] = passcode;


        int? count = HttpContext.Session.GetInt32("Counter");   
        count +=1;
        HttpContext.Session.SetInt32("Counter", (int) count);
        return RedirectToAction("Index");
    
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
