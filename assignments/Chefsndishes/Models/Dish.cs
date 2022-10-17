// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.ComponentModel.DataAnnotations;
using Chefsndishes.Models;

public class Dish

{
    [Key]
    public int DishId {get;set;}

    [Required(ErrorMessage ="is required")]
    [MaxLength(45, ErrorMessage = "must be less than 45 characters.")]
    public string Name {get; set;}

    [Required(ErrorMessage ="is required")]
    [Range(1,5, ErrorMessage ="must set a value")]
    public int Tastiness {get; set;}

    [Required(ErrorMessage ="is required")]
    [Range(1,3000, ErrorMessage ="max of 3000 calorie")]
    public int Calories {get; set;}

    [Required(ErrorMessage ="is required")]
    [MinLength (2, ErrorMessage ="must have atleast 2 characters")]
    public string Description {get; set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;

    public DateTime UpdatedAt {get;set;} = DateTime.Now;


    [Required(ErrorMessage ="is required")]
    [Display(Name = "Chef's Name")]
    public int UserId { get; set; }

    public User? Chef { get; set; }

}