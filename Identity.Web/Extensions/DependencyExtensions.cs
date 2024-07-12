using Identity.Web.Models;

namespace Identity.Web.Extensions;

public static class DependencyExtensions
{
    public static void AddIdentityExtenstion(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz1234567890_";
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireDigit = false;
        }).AddEntityFrameworkStores<AppDbContext>();
    }
}