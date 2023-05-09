﻿using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Services.Repository
{
    public class EmployerRepository : BaseRepository<Employer>, IEmployerRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Employer>> GetAll()
        {
            var allEmployeers = await _context.Employer
               .Include(x => x.JobOffered)
               .ToListAsync();

            return allEmployeers;
        }
        public override async Task<Employer> GetById(int id)
        {
            var employeer = await _context.Employer
                .Include(x => x.JobOffered)
                .ThenInclude(x=> x.AllJobsClasses)
                .ThenInclude(x=> x.JobClass).Where(x=> x.Id == id).FirstOrDefaultAsync();
            return employeer;
        }
    }
}
