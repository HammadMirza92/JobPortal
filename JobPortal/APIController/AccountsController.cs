
using JobPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _sigInManager;
        private readonly IConfiguration _configuration;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountsController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> sigInManager, 
            IConfiguration configuration, 
            RoleManager<IdentityRole> roleManager, 
            IUserStore<IdentityUser> userStore
            )
        {
            _userManager = userManager;
            _sigInManager = sigInManager;
            _userStore = userStore;
            _configuration = configuration;
            _emailStore = GetEmailStore();
            _roleManager = roleManager;


        }
        [HttpPost("create")]
        public async Task<ActionResult<AuthenticationResponse>> Create([FromBody] UserCradential userCradential,bool candidate)
        {
            var user = CreateUser();

            await _userStore.SetUserNameAsync(user, userCradential.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, userCradential.Email, CancellationToken.None);

           /* user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;*/

            var result = await _userManager.CreateAsync(user, userCradential.Password);
          /*  var user = new IdentityUser { UserName = userCradential.Email, Email = userCradential.Email };
            var result = await _userManager.CreateAsync(user, userCradential.Password);*/
            if (candidate && result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                return await BuilToken(userCradential);
               
            }
            else if(!candidate)
            {
                await _userManager.AddToRoleAsync(user, "company");
                return await BuilToken(userCradential);
            }
            else
            {
                return BadRequest(result.Errors);
            }
           
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] UserCradential userCradential)
        {
            var result = await _sigInManager.PasswordSignInAsync(userCradential.Email,userCradential.Password,isPersistent:false,lockoutOnFailure:false);

            if (result.Succeeded)
            {
                return await BuilToken(userCradential);
            }
            else
            {
                return BadRequest("Incorrect Login");
            }
        }
        [Authorize]
        [HttpGet("currentUserRole/{email}")]
        public async Task<IActionResult> currentUserRole(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            var roles = await _userManager.GetRolesAsync(user);

            if (roles == null || roles.Count == 0)
            {
                return BadRequest("User does not have any roles");
            }

            var role = await _roleManager.FindByNameAsync(roles[0]);

            if (role == null)
            {
                return BadRequest("User's role not found");
            }
            var name = role.Name.ToJson();

          return Ok(name);
       //   return Ok("Company");


        }

        private async Task<AuthenticationResponse> BuilToken(UserCradential userCradential)
        {
            var claims = new List<Claim>() {
             new ("email",userCradential.Email)            
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["keyjwt"]));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            
            var expiration = DateTime.Now.AddDays(5);


            var token = new JwtSecurityToken(issuer:null,audience:null,claims:claims,expires: expiration, signingCredentials:creds);

            return new AuthenticationResponse() 
            { 
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,

            };

        }



        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
    }
}
