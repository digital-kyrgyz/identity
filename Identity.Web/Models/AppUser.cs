using Microsoft.AspNetCore.Identity;

namespace Identity.Web.Models;

public class AppUser : IdentityUser
{
    public string City { get; set; }
}