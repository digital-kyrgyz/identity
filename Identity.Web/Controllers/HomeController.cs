using System.Diagnostics;
using Identity.Web.Dtos;
using Microsoft.AspNetCore.Mvc;
using Identity.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AppUser> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        var identityResult = await _userManager.CreateAsync(new()
        {
            UserName = dto.UserName,
            Email = dto.Email,
            PhoneNumber = dto.Phone,
            City = dto.City
        }, dto.Password);

        if (identityResult.Succeeded)
        {
            TempData["SuccessMessage"] = "Sign up was successfully";
            return View();
        }

        foreach (IdentityError error in identityResult.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}