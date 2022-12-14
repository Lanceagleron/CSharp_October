using EntityFrameworkLecture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PostsController : Controller
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

    private ForumContext db;
    public PostsController(ForumContext context)
    {
        db = context;
    }

    [HttpGet("/posts/new")]
    public IActionResult New()
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        return View("New");
    }

    [HttpPost("/posts/create")]
    public IActionResult Create(Post newPost)
    {
        if (!loggedIn || uid == null)//"uid == null" add this to remove the error from "(int)uid;
        {
            return RedirectToAction("Index", "Users");
        }
        if (!ModelState.IsValid)
        {
            // send back to the page w/ the form so error message are displayed
            // can call the New() function because we didnt default the returned view whithin it
            // allows  that method to run w/o creating a new request response cycle (so we keep our errors)
            return New();
                // View("New");
        }
        
        //attatching currently logged in user's ID to the newPost
        newPost.UserId = (int)uid;

        Console.WriteLine(newPost.PostId);
        // ModelState Is valid
        db.Posts.Add(newPost);
        //db doesn't update until we run save changes
        // after SaveChanges, our newPost object will have its PostId update from the db auto-generated id
        db.SaveChanges();
        Console.WriteLine(newPost.PostId);

        return RedirectToAction("All");

         /*
        The ORM .Add method generated a SQL insert mapping the new post properties
        to their corresponding SQL columns, like so:

        INSERT INTO posts (Topic, Body, ImgUrl, CreatedAt, UpdatedAt)
        VALUES (newPost.Topic, newPost.Body, newPost.ImgUrl, NOW(), NOW());
        */
    }

    [HttpGet("/posts")]
    public IActionResult All()
    {
        if (!loggedIn )
        {
            return RedirectToAction("Index", "Users");
        }

        //get all posts, and include info for each individual post in addition to the foreign key
        List<Post> allPosts = db.Posts
        //.include always gives you the entity from the queried table so both
        //.include statements refer to Post
        .Include(p => p.Author)
        .Include(p => p.PostLikes)
        .ToList();
            //^ what you have to write in SQL
        // SELECT * FROM posts JOIN users on post.UserId = user.UserId
        
        return View("All", allPosts);
    }

    [HttpGet("/posts/{onePostId}")]
    public IActionResult GetOnePost(int onePostId)
    {
        if (!loggedIn )
        {
            return RedirectToAction("Index", "Users");
        }
        Post? post = db.Posts
        .Include(p => p.Author)
        .Include(p => p.PostLikes)
            .ThenInclude(l => l.User)
        .FirstOrDefault(p => p.PostId == onePostId);

        // In case user manually types in an invalid ID in the url
        if (post == null)
        {
            return RedirectToAction("All");
        }
        return View("Details", post);
    }

    [HttpPost("/posts/{deletedPostId}/delete")]
    public IActionResult DeletePost(int deletedPostId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        Post? post = db.Posts.FirstOrDefault(p => p.PostId == deletedPostId);

        if (post != null && post.UserId == uid)
        {
            db.Posts.Remove(post);
            db.SaveChanges();
        }
        return RedirectToAction("All");
    }

    [HttpGet("/posts/{postId}/edit")]
    public IActionResult Edit(int postId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        Post? post = db.Posts.FirstOrDefault(p => p.PostId == postId );

        if(post == null || post.UserId != uid)
        {
            return RedirectToAction("All");
        }
        return View("Edit", post);
    }

    [HttpPost("/posts/{postId}/update")]
    public IActionResult Update(Post editedPost, int postId)
    {
        if (!loggedIn)
        {
            return RedirectToAction("Index", "Users");
        }
        if(ModelState.IsValid == false)
        {
            return Edit(postId);
        }
        Post? dbPost = db.Posts.FirstOrDefault(p => p.PostId == postId);

        if (dbPost == null || dbPost.UserId != uid)
        {
            return RedirectToAction("All");
        }

        dbPost.Topic = editedPost.Topic;
        dbPost.Body = editedPost.Body;
        dbPost.ImgUrl = editedPost.ImgUrl;
        dbPost.UpdatedAt = DateTime.Now;

        db.Posts.Update(dbPost);
        db.SaveChanges();

        return Redirect($"/posts/{dbPost.PostId}");
        // return RedirectToAction("GetOnePost", new {postId = dbPost.PostId});
    }

    [HttpPost("/posts/{postId}/like")]
    public IActionResult Like(int postId)
    {
        if(!loggedIn || uid == null)
        {
            return RedirectToAction("Index", "Users");
        }

        UserPostLike? existingLike = db.UserPostLikes
            .FirstOrDefault(l => l.PostId == postId && l.UserId == (int)uid);

        if (existingLike == null)
        {
            UserPostLike newLike = new UserPostLike()
            {
                UserId = (int)uid,
                PostId = postId
            };

            db.UserPostLikes.Add(newLike);
        }
        else
        {
            db.UserPostLikes.Remove(existingLike);
        }
        
        db.SaveChanges();
        return RedirectToAction("All");
    }
}