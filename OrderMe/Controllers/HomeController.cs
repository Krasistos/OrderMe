using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderMe.Infrastructure.Data.Models;

public class HomeController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
}
