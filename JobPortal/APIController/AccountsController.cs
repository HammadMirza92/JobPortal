
using JobPortal.Models;
using JobPortal.Services.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;
using static IdentityServer4.Models.IdentityResources;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IApplicationUserRepository _appUserManager;
        private readonly IEmailRepository _emailRepository;
        public AccountsController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            IConfiguration configuration, 
            RoleManager<IdentityRole> roleManager, 
            IUserStore<IdentityUser> userStore,
            IApplicationUserRepository appUserManager,
            IEmailRepository emailRepository
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userStore = userStore;
            _configuration = configuration;
            _emailStore = GetEmailStore();
            _roleManager = roleManager;
            _appUserManager = appUserManager;
            _emailRepository = emailRepository;
        }

        // POST: api/Accounts/createEmployer
        [HttpPost("createEmployer")]
        public async Task<ActionResult<AuthenticationResponse>> CreateEmployer([FromBody] UserCradential userCradential)
        {
           // var user = CreateUser();

           // await _userStore.SetUserNameAsync(user, userCradential.Email, CancellationToken.None);
           // await _emailStore.SetEmailAsync(user, userCradential.Email, CancellationToken.None);

            var user = new ApplicationUser
            {
                UserName = userCradential.Email,
                Email = userCradential.Email
            };


            var result = await _userManager.CreateAsync(user, userCradential.Password);
          
            if( result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "employer");
                return await BuilToken(userCradential);
            }
            else
            {
                return BadRequest(result.Errors);
            }
           
        }


        // POST: api/Accounts/createCandidate
        [HttpPost("createCandidate")]
        public async Task<ActionResult<AuthenticationResponse>> CreateCandidate([FromBody] UserCradential userCradential)
        {
            /*var user = CreateUser();

            await _userStore.SetUserNameAsync(user, userCradential.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, userCradential.Email, CancellationToken.None);
*/
            var user = new ApplicationUser
            {
                UserName = userCradential.Email,
                Email = userCradential.Email
            };

            var result = await _userManager.CreateAsync(user, userCradential.Password);

            if (result.Succeeded)
            {
                 await _userManager.AddToRoleAsync(user, "candidate");
                 return await BuilToken(userCradential);
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }


        // POST: api/Accounts/confirmEmail
        [HttpPost("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmail model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
             var token = HttpUtility.UrlEncode(model.Token);
            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();

        }


        // POST: api/Accounts/login
        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] UserCradential userCradential)
        {
            var result = await _signInManager.PasswordSignInAsync(userCradential.Email, userCradential.Password, isPersistent: false, lockoutOnFailure: false);



            if (result.Succeeded)
            {
                return await BuilToken(userCradential);
            }
            else
            {
                return BadRequest("Incorrect Login");
            }
        }

             
        //Build Token 
        private async Task<AuthenticationResponse> BuilToken(UserCradential userCradential)
        {
            var user = await _appUserManager.FindUserByEmail(userCradential.Email);

            var roles = await _userManager.GetRolesAsync(user);

            var role = await _roleManager.FindByNameAsync(roles[0]);
            var  tokenRole = role.ToString();

            // Token calims
            var claims = new List<Claim>() {
              new ("user",userCradential.Email),
              new ("email",userCradential.Email),
              new ("role",tokenRole),

            };
           

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["keyjwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Token exp date
            var expiration = DateTime.Now.AddDays(2);
            
            //create token
            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: creds);

            // return response as an AuthenticationResponse
            return new AuthenticationResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                User = user,
                Role = tokenRole,
                EmployerId = user.EmployerId,
                Employer = user.Employer,
                CandidateId = user.CandidateId,
                Candidate = user.Candidate,
            };

        }


        // Create New User
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
