// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace EntityFrameworkLecture.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public int UserId {get;set;}

    [Required(ErrorMessage ="is required")]
    [Display(Name = "User Name")]
    public string Username {get; set;}

    [Required(ErrorMessage ="is required")]
    [MinLength(8, ErrorMessage ="must be atleast 8 characters.")]
    [DataType(DataType.Password)]
    public string Password {get; set;}

    [NotMapped]// won't add column in db
    [Compare("Password", ErrorMessage ="doesn't match password")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword {get; set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;

    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    /**********************************************************************
    Relationship properties below

    Foreign Keys: id of a different (foreign) model.
    
    Navigation props:
        data type is a related model
        MUST use .Include for the nav prop data to be included via a SQL JOIN.
    **********************************************************************/
    public List<Post> UserPost { get; set; } = new List<Post>();
}