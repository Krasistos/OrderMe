using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderMe.Core.Contracts;

public class HomeController : Controller
{
    private readonly IHomeService homeService;
    public HomeController(IHomeService homeService)
    {
        this.homeService = homeService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
       return View();
    }

    public async Task<IActionResult> RefreshVehiclesAndDrivers()
    {
        await homeService.RefreshVehiclesAndDriversAsync();
        return RedirectToAction(nameof(Index));
    }
}
