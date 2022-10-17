// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Chefsndishes.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public int UserId {get;set;}

    [Required(ErrorMessage ="is required")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage ="is required")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage ="is required")]
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime DoB { get; set; }

    public DateTime CreatedAt { get;set; } = DateTime.Now;

    public DateTime UpdatedAt { get;set; } = DateTime.Now;

    public List<Dish> UserDish { get; set; } = new List<Dish>();

    public int GetAge()
    {
        DateTime CurrentYear = DateTime.Now;
        int Age = CurrentYear.Year - DoB.Year;

        return Age;
    }
}