using Identity.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Web.Validations;

public class UserValidator : IUserValidator<AppUser>
{
    public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
    {
        var errors = new List<IdentityError>();

        var isDigit = int.TryParse(user.UserName![0].ToString(), out _);

        if (isDigit)
        {
            errors.Add(new() { Code = "UserNameContainFirstLetterDigit", Description = "Имя пользователя не можеть начаться с цифрой"});
        }
        
        if (errors.Any())
        {
            return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }

        return Task.FromResult(IdentityResult.Success);
    }
}