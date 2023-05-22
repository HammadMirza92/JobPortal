using JobPortal.AppDbContext;
using JobPortal.Enums;
using JobPortal.Models;
using JobPortal.Services.IRepository;
using JobPortal.Services.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using static IdentityServer4.Models.IdentityResources;
using System.Net.Mime;

namespace JobPortal.Services.Repository
{
    public class EmailRepository : BaseRepository<SendEmail>, IEmailRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        public EmailRepository(ApplicationDbContext context, IConfiguration config) : base(context)
        {
            _context = context;
            _config = config;
        }

        // Email when candidate applied to any job  || Email when company want to get CSV 
        public async Task SendEmail(SendEmail email, string? attachmentPath)
        {
            SmtpClient client = await GetSMTPSettings();

            MailMessage message = new MailMessage();
            message.From = new MailAddress("hammad.hassan@purelogics.com");
            message.To.Add(email.To);
            message.Subject = email.Subject;
            message.Body = email.Body;
            message.IsBodyHtml = true;

            if (attachmentPath != null)
            {
                Attachment attachment = new Attachment(attachmentPath, MediaTypeNames.Text.Plain);
                message.Attachments.Add(attachment);
            }
           


            client.Send(message);

        }

        // Email Company to candidate For confirmation
        public async Task SendConfirmationEmail(ApplicationUser appUser, string token)
        {
            var body = "Hello Thank you for your registration at GEt To Job and here is your eail confirmation link ->  "+token;
            SmtpClient client = await GetSMTPSettings();

            MailMessage message = new MailMessage();
            message.From = new MailAddress("hammad.hassan@purelogics.com");
            message.To.Add(appUser.Email);
            message.Subject = "Account Confirmation !";
            message.Body = body;
            message.IsBodyHtml = true;

            client.Send(message);
        }

        // Create SMTP Client
        public async Task<SmtpClient> GetSMTPSettings()
        {
            SmtpClient client = new SmtpClient();
            client.Host = _config.GetSection("SMTPHost").Value;
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            return client;
        }
    }
}
