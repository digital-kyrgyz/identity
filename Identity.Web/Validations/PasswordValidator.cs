using Identity.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Web.Validations;

public class PasswordValidator : IPasswordValidator<AppUser>
{
    public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
    {
        var errors = new List<IdentityError>();
        
        if (password!.ToLower().Contains(user.UserName!.ToLower()))
        {
            errors.Add(new() {Code = "PasswordContainUserName", Description = "Пароль не может содержать имя пользователя"});
        }

        if (password!.ToLower().StartsWith("1234"))
        {
            errors.Add(new (){Code = "PasswordContain1234", Description = "Пароль не может содержать 1234"});
        }

        if (errors.Any())
        {
            return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }

        return Task.FromResult(IdentityResult.Success);
    }
}