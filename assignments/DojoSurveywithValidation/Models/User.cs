#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

public class User
{
    [Required(ErrorMessage = "is required.")]
    [MinLength(2, ErrorMessage = "must be atleast 2 characters.")]
    [Display(Name ="User Name")]
    public string username { get; set; }

    [Required(ErrorMessage = "is required.")]
    [Display(Name ="Dojo Location")]
    public string location { get; set; }
    
    [Required(ErrorMessage = "is required.")]
    [Display(Name ="Favorite Language")]
    public string language { get; set; }
    
    [Required(ErrorMessage = "is required.")]
    [Display(Name ="Comment")]
    public string comment { get; set; }

}