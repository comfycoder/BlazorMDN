using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ComfyPWA.Shared.Models;

namespace ComfyPWA.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(IConfiguration configuration,
                               SignInManager<AppUser> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(
                    login.Email, login.Password, false, false);

                if (!result.Succeeded) return BadRequest(
                    new LoginResult
                    {
                        Successful = false,
                        Error = "Username or Password is Invalid"
                    });

                var claims = new List<Claim>();
                var user = await _signInManager.UserManager.FindByEmailAsync(login.Email);
                var roles = await _signInManager.UserManager.GetRolesAsync(user);

                claims.Add(new Claim(ClaimTypes.Name, login.Email));
                claims.Add(new Claim("FullName", user.FullName));

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

                var token = new JwtSecurityToken(
                    _configuration["JwtIssuer"],
                    _configuration["JwtAudience"],
                    claims,
                    expires: expiry,
                    signingCredentials: creds
                );

                return Ok(new LoginResult
                {
                    Successful = true,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception exception)
            {
                var message = exception.Message;
                //TODO: Log

                return BadRequest(new LoginResult
                {
                    Successful = false,
                    Error = message
                });
            }
        }
    }
}
