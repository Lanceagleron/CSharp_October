// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId { get; set; }


    [Required(ErrorMessage ="is required")]
    [Display(Name = "Wedder One")]
    public string WedderOne { get; set; }


    [Required(ErrorMessage ="is required")]
    [Display(Name = "Wedder Two")]
    public string WedderTwo { get; set; }


    [Required(ErrorMessage ="is required")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }


    [Required(ErrorMessage ="is required")]
    public string Address { get; set; }


    public DateTime CreatedAt {get;set;} = DateTime.Now;


    public DateTime UpdatedAt {get;set;} = DateTime.Now;


    public int UserId { get; set; }


    public User? Planner { get; set; }


    public List<UserWeddingRsvp> WeddingRsvps { get; set; } = new List<UserWeddingRsvp>();
}