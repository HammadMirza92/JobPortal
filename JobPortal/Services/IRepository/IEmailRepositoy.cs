using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Models.ModelBase;
using JobPortal.Services.IRepository.Base;

namespace JobPortal.Services.IRepository
{
    public interface IEmailRepository : IBaseRepository<SendEmail>
    {
        Task SendEmail(SendEmail email,string? attachmentPath);
        Task SendConfirmationEmail(ApplicationUser appUser, string token);
    }
}
