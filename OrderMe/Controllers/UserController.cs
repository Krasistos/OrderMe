using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.User;
using OrderMe.Infrastructure.Data.Common;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Controllers
{
    public class UserController : BaseController, IDriverService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository repository;

        public UserController(UserManager<ApplicationUser> _userManager
            , IRepository repos)
        {
            userManager = _userManager;
            repository = repos;
        }
        public async Task<IActionResult> Profile()
        {
            var user = await userManager.FindByIdAsync(User.Id());

            var driver = await repository.AllReadOnly<Driver>().FirstOrDefaultAsync(x => x.UserId == User.Id());

            string firstName = user.FirstName;
            string lastName = user.LastName;

            var model = new UserShowProfileViewModel
            {
                FirstName = firstName == null ? " " : user.FirstName,
                LastName = lastName == null ? " " : user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsDriver =  driver != null ? true : false
            };

            return View(model);
        }

        //Driver things
        public async Task<IActionResult> Become()
        {
            var driver = await repository.AllReadOnly<Driver>().FirstOrDefaultAsync(x => x.UserId == User.Id());

            if (driver != null)
            {
                return BadRequest(new { message = "You are already a driver" });
            }

            await repository.AddAsync<Driver>(new Driver
            {
                UserId = User.Id(),
                IsActive = false,
                CreatedAt = DateTime.Now
            });
            await repository.SaveChangesAsync();

            return RedirectToAction(nameof(Profile));
        }
        public async Task<IActionResult> StopBeing()
        {
            var driver = await repository.All<Driver>().FirstOrDefaultAsync(x => x.UserId == User.Id());

            if (driver != null)
            {
                await repository.DeleteAsync<Driver>(driver.Id);
                await repository.SaveChangesAsync();
            }

          return RedirectToAction(nameof(Profile));
        }
    }
}
