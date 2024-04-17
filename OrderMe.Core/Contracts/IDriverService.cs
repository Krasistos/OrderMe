using Microsoft.AspNetCore.Mvc;

namespace OrderMe.Core.Contracts
{
    public interface IDriverService
    {
        Task<IActionResult> Become();
        Task<IActionResult> StopBeing();
    }
}
