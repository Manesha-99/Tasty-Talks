using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tasty_Talks_BackEnd.Model.DTO;

namespace Tasty_Talks_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }


        //Register User Function----
        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> RegisterUser([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.Email,
                PhoneNumber = registerRequestDTO.PhoneNumber,
            };

            var identityResult =  await userManager.CreateAsync(identityUser, registerRequestDTO.Password);

            if (identityResult.Succeeded)
            {
                //Adding Role To the User
                if (registerRequestDTO.Role != null)
                {
                    identityResult = await userManager.AddToRoleAsync(identityUser, registerRequestDTO.Role);

                    if (identityResult.Succeeded) 
                    {
                        return Ok("User Registration Successfully....");
                    }
                }
            }

            return BadRequest("Something went wrong....");
        }
    }
}
