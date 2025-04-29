using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tasty_Talks_BackEnd.Model.DTO;
using Tasty_Talks_BackEnd.Repositories;

namespace Tasty_Talks_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        //Register User Function----------------------------------------------------------------
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
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);

                    if (identityResult.Succeeded) 
                    {
                        return Ok("User Registration Successfully....");
                    }
                }
            }

            return BadRequest("Something went wrong....");
        }


        //Login User Function---------------------------------------------------------------------
        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> LoginUser([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await userManager.FindByNameAsync(loginRequestDTO.UserName);

            if (user != null)
            {
                
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

                if (checkPasswordResult)
                {
                    //Create Token----

                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null) 
                    {
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var loginresponse = new LoginResponseDTO
                        {
                            JWTToken = jwtToken,
                        };

                        return Ok(loginresponse);
                    }

                    return BadRequest("Something went wrong....");
                    
                }
                
            }

            return BadRequest("Credentials Mismatch.....");
        }

    }
}
