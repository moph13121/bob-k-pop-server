using bob_api.Data;
using bob_api.Models;
using bob_api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bob_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly DatabaseContext _context;
        private readonly TokenService _tokenService;

        public UsersController(UserManager<User> userManager, DatabaseContext context,
            TokenService tokenService, ILogger<UsersController> logger)
        {
            _userManager = userManager;
            _context = context;
            _tokenService = tokenService;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Registration request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(
                new User { FirstName = request.FirstName, LastName = request.LastName, Email = request.Email, UserName = request.Email, Password = request.Password  },
                request.Password!

            );

            if (result.Succeeded)
            {
                request.Password = "";
                return CreatedAtAction(nameof(Register), new { email = request.Email }, request);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthenticationResponse>> Authenticate([FromBody] Authentication request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == request.email!.ToLower());

            if (managedUser == null)
            {
                return BadRequest("Bad email credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password!);

            if (!isPasswordValid)
            {
                return BadRequest("Bad password credentials");
            }

            var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.email);

            if (userInDb is null)
            {
                return Unauthorized();
            }

            var accessToken = _tokenService.CreateToken(userInDb);
            await _context.SaveChangesAsync();

            return Ok(new AuthenticationResponse
            {
                Email = userInDb.Email,
                Token = accessToken,
            });
        }
    }
}
