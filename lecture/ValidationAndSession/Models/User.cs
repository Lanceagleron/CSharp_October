// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;

public class User
{
    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters.")]
    [MaxLength(20, ErrorMessage = "must be less than 20 characters.")]
    [Display(Name = "User Name")]
    public string Username {get; set;}

    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "must be at least 8 characters")]
    public string Password {get; set;}

    [Required(ErrorMessage = "is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "must match Password")]
    public string ConfirmPassword {get; set;}
}