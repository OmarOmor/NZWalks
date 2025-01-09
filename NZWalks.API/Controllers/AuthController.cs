using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepo;
        public AuthController(UserManager<IdentityUser> userManager,ITokenRepository tokenRepo)
        {
            _userManager = userManager;
            _tokenRepo = tokenRepo;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequestDTO registerDTO)
        {
            var identityUsr = new IdentityUser
            {
                UserName = registerDTO.Username,
                Email = registerDTO.Username
            };

            var identityResult = await _userManager.CreateAsync(identityUsr,registerDTO.Password);
            if(identityResult.Succeeded)
            {
                if(registerDTO.Roles != null && registerDTO.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(identityUsr, registerDTO.Roles);    

                    if(identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please Login!");
                    }
                }
            }
            return Ok("Register successful");
        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDTO.Username);

            if(user != null)
            {
                var passwordCheckResult = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

                if(passwordCheckResult)
                {

                    //Get roles for this user
                    var roles = await _userManager.GetRolesAsync(user);

                    if(roles != null)
                    {
                        //Generate tokens
                        var jwtToken = _tokenRepo.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(response);
                    } 
                }
            }

            return BadRequest("Username or password incorrect!");
        }
    }
}
