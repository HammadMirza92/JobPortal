using JobPortal.Models.ModelBase;

namespace JobPortal.Models
{
    public class SendEmail:BaseModel
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
