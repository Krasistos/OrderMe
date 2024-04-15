using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using OrderMe.Infrastructure.Data;
using OrderMe.Infrastructure.Data.Common;
using OrderMe.Infrastructure.Data.Models;
using OrderMe.Models;
using static OrderMe.Infrastructure.Constants.DataConstants;

public class HomeController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext context;

    public HomeController(UserManager<ApplicationUser> userManager,ApplicationDbContext _context)
    {
        _userManager = userManager;
        context = _context;
    }

    public async Task<IActionResult> Index()
    {
        //var model = new HomeViewModel()
        //{
        //    CarUrl = context.Vehicles.FirstOrDefault().ImageUrl,
        //    PancakesUrl = context.MenuItems.FirstOrDefault().ImageUrl
        //};
        //return View(model);

        var menuItems = context.MenuItems.ToList();
        var vehicles = context.Vehicles.ToList();

        var viewModel = new MenuAndVehicleViewModel
        {
            MenuItems = menuItems,
            Vehicles = vehicles
        };

        return View(viewModel);

    }
}
