using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderMe.Core.Contracts;

public class HomeController : Controller
{
    private readonly IGarageService garageService;
    public HomeController(IGarageService _garageService)
    {
        garageService = _garageService;
    }
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
       // return View();

        var model = await garageService.AllGaragesAsync();
        return View(model);

    }
}
