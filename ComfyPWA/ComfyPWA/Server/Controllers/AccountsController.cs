using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComfyPWA.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ComfyPWA.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterModel model)
        {
            var newUser = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                return BadRequest(new RegisterResult { Successful = false, Errors = errors });
            }

            //--- Add all new users to the User role
            await _userManager.AddToRoleAsync(newUser, "User");

            //TODO: Temporary
            // Add new users whose email starts with 'admin' to the Admin role
            //if (newUser.Email.StartsWith("admin"))
            //{
            //    await _userManager.AddToRoleAsync(newUser, "Admin");
            //}

            return Ok(new RegisterResult { Successful = true });
        }
    }
}
