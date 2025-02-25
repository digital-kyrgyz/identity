﻿using Identity.Web.Areas.Admin.Models;
using Identity.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public HomeController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> UserList()
    {
        var userList = await _userManager.Users.ToListAsync();

        var userDtos = userList.Select(x => new UserDto()
        {
            Id = x.Id,
            Email = x.Email,
            UserName = x.UserName,
            City = x.City,
            Phone = x.PhoneNumber
        }).ToList();
        
        return View(userDtos);
    }
}