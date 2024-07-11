using System.ComponentModel.DataAnnotations;

namespace Identity.Web.Dtos;

public class SignUpDto
{
    [Required(ErrorMessage = "User name is required")]
    [Display(Name = "User name")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email format is wrong")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Phone is required")]
    [Display(Name = "Phone")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "City is required")]
    [Display(Name = "City")]
    public string City { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    [Required(ErrorMessage = "Password confirm is required")]
    [Display(Name = "Password confirm")]
    public string PasswordConfirm { get; set; }
}