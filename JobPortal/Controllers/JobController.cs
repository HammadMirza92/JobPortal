using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobRepository _jobRepository;
        public JobController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        // GET: JobController
        public async Task<ActionResult> Index()
        {
            var jobs = await _jobRepository.GetAll();
         
            return View(jobs);
        }

        // GET: JobController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var job = await _jobRepository.GetById(id);
            return View(job);
        }
        
        // GET: JobController/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: JobController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Job job)
        {
            var newJob= await _jobRepository.Add(job);
            
            return RedirectToAction(nameof(Index));
            
        }
        [Authorize("Admin")]
        // GET: JobController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        [Authorize("Admin")]
        // POST: JobController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Filter(string Title, JobStatus Status, JobType Type, double StartBudget, double EndBudget, int Vacancy, string Location, DateTime StartDate, DateTime EndDate)
        {
            var result = await _jobRepository.FilterJob(Title, Status, Type, StartBudget, EndBudget, Vacancy, Location, StartDate, EndDate);
            return View(result);
        }
    }
}
