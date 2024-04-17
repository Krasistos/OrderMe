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

        //[HttpPost]
        //[Route("api/user/register")]
        //public async Task<IActionResult> Register([FromBody] RegisterModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = new ApplicationUser
        //    {
        //        UserName = model.Email,
        //        Email = model.Email,
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        PhoneNumber = model.PhoneNumber,
        //        Address = model.Address,
        //        CreatedAt = DateTime.Now
        //    };

        //    var result = await _userManager.CreateAsync(user, model.Password);

        //    if (result.Succeeded)
        //    {
        //        await _userManager.AddToRoleAsync(user, "Customer");

        //        return Ok(new { message = "User created successfully" });
        //    }

        //    return BadRequest(new { message = "User creation failed" });
        //}

        //[HttpPost]
        //[Route("api/user/login")]
        //public async Task<IActionResult> Login([FromBody] LoginModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = await _userManager.FindByEmailAsync(model.Email);

        //    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        //    {
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //            {
        //                new Claim("UserID", user.Id.ToString())
        //            }),
        //            Expires = DateTime.UtcNow.AddDays(1),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])), SecurityAlgorithms.HmacSha256Signature)
        //        };

        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        //        var token = tokenHandler.WriteToken(securityToken);

        //        return Ok(new { token });
        //    }

        //    return BadRequest(new { message = "Invalid credentials" });
        //}

        //[HttpGet]
        //[Route("api/user/profile")]
        //[Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await userManager.FindByIdAsync(User.Id());

            //  var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.UserId == user.Id);

            string firstName = user.FirstName;
            string lastName = user.LastName;

            return Ok(
                new UserShowProfileViewModel
                {
                    FirstName = firstName == null ? " " : user.FirstName,
                    LastName = lastName == null ? " " : user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    IsDriver = true
                });
        }

        //Driver things
        public async Task<IActionResult> Become()
        {
            var driver = await repository.AllReadOnly<Driver>().FirstOrDefaultAsync(x => x.UserId == User.Id());

            if(driver != null)
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

            var user = await userManager.FindByIdAsync(User.Id());

            //  var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.UserId == user.Id);

            string firstName = user.FirstName;
            string lastName = user.LastName;

            var profile = new UserShowProfileViewModel
                {
                    FirstName = firstName == null ? " " : user.FirstName,
                    LastName = lastName == null ? " " : user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    IsDriver = true
                };

            return View(nameof(Profile),profile);
        }
        public async Task<IActionResult> StopBeing()
        {
            var driver = await repository.All<Driver>().FirstOrDefaultAsync(x => x.UserId == User.Id());

            if (driver != null)
            {
                await repository.DeleteAsync<Driver>(driver.Id);
                await repository.SaveChangesAsync();
            }

            var user = await userManager.FindByIdAsync(User.Id());

            //  var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.UserId == user.Id);

            string firstName = user.FirstName;
            string lastName = user.LastName;

            var profile = new UserShowProfileViewModel
            {
                FirstName = firstName == null ? " " : user.FirstName,
                LastName = lastName == null ? " " : user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsDriver = true
            };
            return View(nameof(Profile),profile);
        }
    }
}
