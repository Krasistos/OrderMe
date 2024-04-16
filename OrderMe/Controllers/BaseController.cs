using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrderMe.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
