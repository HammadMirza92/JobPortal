using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace JobPortal.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    /* [Authorize(Roles = "employer")]*/
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IApplicationUserRepository _appUserRepository;
        public CandidateController(ICandidateRepository candidateRepository, IApplicationUserRepository applicationUserRepository)
        {
            _candidateRepository = candidateRepository;
            _appUserRepository = applicationUserRepository;
        }

        // GET: api/Candidate
        [HttpGet]
        [ResponseCache(Duration = 120)]
        public async Task<ActionResult<Candidate>> Get()
        {

            var allCandidates = await _candidateRepository.GetAll();
            if (!allCandidates.Any())
            {
                return BadRequest();
            }
            return Ok(allCandidates);
        }

        // GET api/Candidate/{id}
        [HttpGet("{id}")]
        public async Task<Candidate> Get(Guid id)
        {
            var candidate = await _candidateRepository.GetById(id);
            return candidate;
        }

        // POST api/Candidate/create
        [HttpPost("create")]
        public async Task<Candidate> Create(Candidate candidate)
        {
            var newCandidate = await _candidateRepository.Add(candidate); 
            var id = candidate.Id;

            var candidateUser = await _appUserRepository.GetById(candidate.UserId);

            var newUser = new ApplicationUser()
            {
                Id = candidateUser.Id,
                ConcurrencyStamp = candidateUser.ConcurrencyStamp,
                FirstName = candidateUser.FirstName,
                LastName = candidateUser.LastName,
                EmployerId = candidateUser.EmployerId,
                CandidateId = id,
                Email= candidateUser.Email,
                UserName = candidateUser.UserName,
                NormalizedUserName = candidateUser.Email,
                NormalizedEmail = candidateUser.NormalizedEmail,
                EmailConfirmed = candidateUser.EmailConfirmed,
                PasswordHash = candidateUser.PasswordHash,
                SecurityStamp = candidateUser.SecurityStamp,
                PhoneNumber = candidateUser.PhoneNumber,
                LockoutEnabled = candidateUser.LockoutEnabled,
                AccessFailedCount = candidateUser.AccessFailedCount,
            };

            await _appUserRepository.Update(newUser);


            return newCandidate;

          
        }


        // POST api/Candidate/uploadImage
        [HttpPost("uploadImage")]
        public IActionResult UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("No image uploaded.");

            // Generate a unique image file name
            var imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

            if (image != null && image.Length > 0)
            {
                var filePath = Path.Combine("D:\\JobPortal\\src\\assets\\Images\\candidateImgs\\", imageFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                var img = imageFileName.ToJson();
                return Ok(img);
            }

            return BadRequest("No image file received.");
        }


        // DELETE api/Candidate/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // POST api/Candidate/searchCandidate
        [HttpPost("searchCandidate")]
        public async Task<IActionResult> SearchCandidate(SearchCandidate search)
        {
            var filterCandidates = await _candidateRepository.FilterCandidate(search);

            return Ok(filterCandidates);
        }
    }
}
