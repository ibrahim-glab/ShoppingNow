using System.ComponentModel.DataAnnotations;

namespace ShoppingNow.Models;

public class RegisterViewModel
{
    [Required]
    [MaxLength(20)]
    [Display(Name = "First Name")]
    public  string FirstName { get; set; }
    [Required]
    [MaxLength(20)]
    [Display(Name = "Last Name")]
    public  string LastName { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public  string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public  string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password" , ErrorMessage = "Password doesn't match ") ]
    [Display(Name = "Confirm Password")]
    public  string ConfirmPassword { get; set; }
    
}