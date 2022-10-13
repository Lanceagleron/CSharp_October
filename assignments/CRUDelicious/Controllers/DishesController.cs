using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using CRUDelicious.Controllers;

namespace CRUDelicious.Controllers;


public class DishesController : Controller
{
    private MyContext db;
    public DishesController(MyContext context)
    {
        db = context;
    }

    [HttpGet("/dishes/new")]
    public IActionResult New()
    {
        return View("New");
    }

    [HttpPost("/dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if(!ModelState.IsValid)
        {
            return New();
        }
        db.Dishes.Add(newDish);
        db.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    [HttpGet("/dishes/{dishId}")]
    public IActionResult GetOneDish(int dishId)
    {
        Dish? dish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (dish == null)
        {
            return RedirectToAction("Index", "Home");
        }
        return View("Viewone", dish);
    }

    [HttpPost("/dishes/{dishId}/delete")]
    public IActionResult DeleteDish(int dishId)
    {
        Dish? dish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);

        if (dish != null)
        {
            db.Dishes.Remove(dish);
            db.SaveChanges();
        }
        return RedirectToAction("Index", "Home");
    }
    [HttpGet("/dishes/{dishId}/edit")]
    public IActionResult Edit(int dishId)
    {
        Dish? dish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);

        if (dish == null)
        {
            return RedirectToAction("Index", "Home");
        }

        return View("Edit", dish);
    }

    [HttpPost("/dishes/{dishId}/update")]
    public IActionResult Update(Dish editedDish, int dishId)
    {
        if(ModelState.IsValid == false)
        {
            return Edit(dishId);
        }
        Dish? dbDish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);

        if (dbDish == null)
        {
            return RedirectToAction("Index", "Home");
        }
        dbDish.Name = editedDish.Name;
        dbDish.Chef = editedDish.Chef;
        dbDish.Tastiness = editedDish.Tastiness;
        dbDish.Calories = editedDish.Calories;
        dbDish.Description = editedDish.Description;
        dbDish.UpdatedAt = DateTime.Now;

        db.Dishes.Update(dbDish);
        db.SaveChanges();

        // return Redirect($"dishes/{dbDish.DishId}");
        return RedirectToAction("GetOnePost", new {dishId = dbDish.DishId});
    }
}