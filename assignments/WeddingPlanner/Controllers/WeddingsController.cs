using WeddingPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class WeddingsController : Controller
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
    public WeddingsController(MyContext context)
    {
        db = context;
    }


    [HttpGet("/weddings/new")]
    public IActionResult New()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }

        return View("New");
    }


    [HttpPost("/weddings/create")]
    public IActionResult Create(Wedding newWedding)
    {
        if (!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "Users");
        }
        if (!ModelState.IsValid)
        {
            return New();
        }
        newWedding.UserId = (int)uid;

        db.Weddings.Add(newWedding);
        db.SaveChanges();
        return Redirect($"/weddings/{newWedding.WeddingId}");
    }



    [HttpGet("/weddings")]
    public IActionResult All()
    {
        if (!loggedIn )
        {
            return RedirectToAction("Index", "Users");
        }

        List<Wedding> allWeddings = db.Weddings
        .Include(w => w.Planner)
        .Include(w => w.WeddingRsvps)
        .ToList();
        return View("All", allWeddings);
    }
    

    [HttpGet("/weddings/{oneWeddingId}")]
    public IActionResult GetOneWedding(int oneWeddingId)
    {
        if (!loggedIn )
        {
            return RedirectToAction("Index", "Users");
        }
        Wedding? wedding = db.Weddings
        .Include(w => w.Planner)
        .Include(w => w.WeddingRsvps)
            .ThenInclude(r => r.User)
        .FirstOrDefault(w => w.WeddingId == oneWeddingId);

        // In case user manually types in an invalid ID in the url
        if (wedding == null)
        {
            return RedirectToAction("All");
        }
        return View("Details", wedding);
    }


    [HttpPost("/weddings/{deletedWeddingId}/delete")]
    public IActionResult DeleteWedding(int deletedWeddingId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        Wedding? wedding = db.Weddings.FirstOrDefault(p => p.WeddingId == deletedWeddingId);

        if (wedding != null && wedding.UserId == uid)
        {
            db.Weddings.Remove(wedding);
            db.SaveChanges();
        }
        return RedirectToAction("All");
    }

    [HttpPost("/weddings/{weddingtId}/rsvp")]
    public IActionResult Rsvp(int weddingtId)
    {
        if(!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "Users");
        }

        UserWeddingRsvp? existingRsvp = db.UserWeddingRsvps
            .FirstOrDefault(r => r.WeddingId == weddingtId && r.UserId == (int)uid);

        if (existingRsvp == null)
        {
            UserWeddingRsvp newRsvp = new UserWeddingRsvp()
            {
                UserId = (int)uid,
                WeddingId = weddingtId
            };

            db.UserWeddingRsvps.Add(newRsvp);
        }
        else
        {
            db.UserWeddingRsvps.Remove(existingRsvp);
        }
        
        db.SaveChanges();
        return RedirectToAction("All");
    }
}