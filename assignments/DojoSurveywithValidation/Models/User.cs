#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

public class User
{
    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be atleast 2 characters.")]
    [Display(Name ="User Name")]
    public string Username { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name ="Dojo Location")]
    public string Location { get; set; }
    
    [Required(ErrorMessage = "is required.")]
    [Display(Name ="Favorite Language")]
    public string Language { get; set; }
    
    [MinLength(20, ErrorMessage = "must be atleast 20 characters.")]
    [Display(Name ="Comment")]
    public string? Comment { get; set; }
    //string? will pass either null or string
}