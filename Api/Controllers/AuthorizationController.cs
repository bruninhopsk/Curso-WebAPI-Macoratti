using System;
using System.Threading.Tasks;
using Domain.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Consumes("application/json")]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly SignInManager<IdentityUser> SignInManager;

        public AuthorizationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<string> Get()
        {
            return Ok($"Authorization: accessed in {DateTime.UtcNow.ToLongDateString()}");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> RegisterUser([FromBody] UserDTO userDTO)
        {
            var user = new IdentityUser()
            {
                UserName = userDTO.Email,
                Email = userDTO.Email,
                EmailConfirmed = true,
            };

            var result = await UserManager.CreateAsync(user, userDTO.Password);

            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(user, false);

                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Login([FromBody] UserDTO userDTO)
        {
            var result = await SignInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, false);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}