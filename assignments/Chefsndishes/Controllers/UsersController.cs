using Chefsndishes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class UsersController : Controller
{
    private MyContext db;
    public UsersController(MyContext context)
    {
        db = context;
    }



    [HttpGet("/")]
    public IActionResult Index()
    {
        List<User> allUser = db.Users.ToList();
        foreach (var oneChef in allUser)
        {
            List<Dish> allDishes = db.Dishes.Where( d => d.UserId == oneChef.UserId).ToList();
            oneChef.UserDish = allDishes;
        }
        return View("Index", allUser);
    }



    [HttpGet("/chefs/new")]
    public IActionResult NewChef()
    {
        return View("New");
        
    }



    [HttpPost("/chefs/addchef")]
    public IActionResult AddChef(User newUser)
    {
        if (!ModelState.IsValid)
        {
            return NewChef();
        }

        db.Users.Add(newUser);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

}