using Microsoft.AspNetCore.Mvc;
using Chefsndishes.Models;
using Chefsndishes.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Chefsndishes.Controllers;


public class DishesController : Controller
{
    private MyContext db;
    public DishesController(MyContext context)
    {
        db = context;
    }



    [HttpGet("/dishes")]
    public IActionResult GetDishes()
    {
        List<Dish> allDishes = db.Dishes.Include(p => p.Chef).ToList();
        return View("AllDish", allDishes);
    }



    [HttpGet("/dishes/new")]
    public IActionResult New()
    {
        List<User> allChef = db.Users.ToList();
        ViewBag.getallChef = allChef;
        return View("NewDishes");
    }



    [HttpPost("/dishes/adddish")]
    public IActionResult AddDish(Dish newDish)
    {
        if(!ModelState.IsValid)
        {
            return New();
        }
        
        
        db.Dishes.Add(newDish);
        db.SaveChanges();
        return RedirectToAction("GetDishes");
    }

}