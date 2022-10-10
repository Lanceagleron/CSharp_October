using EntityFrameworkLecture.Models;
using Microsoft.AspNetCore.Mvc;


public class PostController : Controller
{
    private ForumContext db;
    public PostController(ForumContext context)
    {
        db = context;
    }
}