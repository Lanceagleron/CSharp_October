using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


public class UsersController : Controller
{
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UUID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }

    private MyContext db;
    public UsersController(MyContext context)
    {
        db = context;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            if(db.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "has been used");
            }
        }
        if (ModelState.IsValid == false)
        {
            return Index();
        }

        PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
        newUser.Password = passwordHasher.HashPassword(newUser, newUser.Password);

        db.Users.Add(newUser);
        db.SaveChanges();

        HttpContext.Session.SetInt32("UUID", newUser.UserId);
        HttpContext.Session.SetString("Email", newUser.Email);
        return RedirectToAction("All", "Weddings");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if(ModelState.IsValid == false)
        {
            return Index();
        }
        User? dbUser = db.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);
    
    if(dbUser == null)
        {
            ModelState.AddModelError("LoginEmail", "/ Password don't match");
            return Index();
        }
        PasswordHasher<LoginUser> passwordHasher = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompareResult = passwordHasher.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);
        
        if (pwCompareResult == 0)
        {
            ModelState.AddModelError("LoginEmail", "/ Password don't match");
            return Index();
        }

        HttpContext.Session.SetInt32("UUID", dbUser.UserId);
        HttpContext.Session.SetString("Email", dbUser.Email);
        return RedirectToAction("All", "Weddings");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}   