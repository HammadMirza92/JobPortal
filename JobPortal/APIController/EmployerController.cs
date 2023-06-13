using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly IApplicationUserRepository _appUserRepository;
        private readonly IJobRepository _jobRepository;


        public EmployerController(IEmployerRepository employerRepository, IApplicationUserRepository appUserRepository, IJobRepository jobRepository)
        {
            _employerRepository = employerRepository;
            _appUserRepository = appUserRepository;
            _jobRepository = jobRepository;     
        }

        // GET: api/Employer
        [HttpGet]
/*        [ResponseCache(Duration = 120)]*/
        public async Task<ActionResult<Employer>> Get()
        {
          
            var allEmployers = await _employerRepository.GetAll();
            if (!allEmployers.Any())
            {
                return BadRequest();
            }
            return Ok(allEmployers);
        }

        // GET api/Employer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employer>> Get(Guid id)
        {
            var employer = await _employerRepository.GetById(id);
            if (employer == null)
            {
                return BadRequest("employer not Found!");
            }
            return employer;
        }

        // POST api/Employer/create
        [HttpPost("create")]
        public async Task<Employer> Create([FromBody] Employer employeer)
        {
            var newEmployeer = await _employerRepository.Add(employeer);
            var id = newEmployeer.Id;

            var employerUser = await _appUserRepository.GetById(employeer.UserId);

            var newUser = new ApplicationUser() { 
                Id= employerUser.Id,
                ConcurrencyStamp = employerUser.ConcurrencyStamp,
                FirstName= employerUser.FirstName,
                LastName= employerUser.LastName,
                EmployerId = id ,
                UserName = employerUser.UserName,
                NormalizedUserName = employerUser.NormalizedUserName,
                Email = employerUser.Email,
                NormalizedEmail = employerUser.NormalizedEmail,
                EmailConfirmed = employerUser.EmailConfirmed,
                PasswordHash = employerUser.PasswordHash,
                SecurityStamp = employerUser.SecurityStamp,
                PhoneNumber = employerUser.PhoneNumber,
                LockoutEnabled = employerUser.LockoutEnabled,
                AccessFailedCount = employerUser.AccessFailedCount,
            };

            try
            {
                await _appUserRepository.Update(newUser);
            }
            catch (Exception)
            {

                BadRequest("app user not updated");
            }
           
            return newEmployeer;

        }

        // POST api/Employer/uploadImage
        [HttpPost("uploadImage")]
        public IActionResult UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("No image uploaded.");

            // Generate a unique image file name
            var imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

            if (image != null && image.Length > 0)
            {
                var filePath = Path.Combine("D:\\JobPortal\\src\\assets\\Images\\companyLogo\\", imageFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                var img = imageFileName.ToJson();
                return Ok(img);
            }

            return BadRequest("No image file received.");
        }


        // DELETE api/Employer/{id}
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }

        // POST api/Employer/searchEmployer
        [HttpPost("searchEmployer")]
        public async Task<IActionResult> SearchEmployer(SearchEmployer search)
        {
            var filterEmployers = await _employerRepository.FilterEmployer(search);
   
            return Ok(filterEmployers);
        }
    }
}
