using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.AuthApp;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // POST: api/account/register
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegistration model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User { UserName = model.LoginProp };
            var createResult = await _userManager.CreateAsync(user, model.Password);

            if (!createResult.Succeeded)
                return BadRequest(createResult.Errors);

            // Ensure role exists
            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(model.Role));
                if (!roleResult.Succeeded)
                    return BadRequest(roleResult.Errors);
            }

            // Assign role
            var roleAssignResult = await _userManager.AddToRoleAsync(user, model.Role);
            if (!roleAssignResult.Succeeded)
                return BadRequest(roleAssignResult.Errors);

            return Ok(new { Message = "User registered successfully" });
        }

        // POST: api/account/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLogin model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var loginResult = await _signInManager.PasswordSignInAsync(model.LoginProp, model.Password, false, lockoutOnFailure: false);

            if (!loginResult.Succeeded)
                return Unauthorized(new { Message = "Invalid login or password" });

            return Ok(new { Message = "Login successful" });
        }

        // POST: api/account/logout
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { Message = "Logout successful" });
        }

        // GET: api/account/users
        [HttpGet("users")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users.Select(u => new { u.Id, u.UserName }).ToList();
            return Ok(users);
        }

        // DELETE: api/account/users/{id}
        [HttpDelete("users/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { Message = "User not found" });

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { Message = "User deleted successfully" });
        }
    }
}
