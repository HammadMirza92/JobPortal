using JobPortal.Models.ModelBase;

namespace JobPortal.Models
{
    public class EmployerToCandidateEmail :BaseModel
    {
        public Guid CompanyId { get; set; }
        public Employer? Employer { get; set; }
        public Guid CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
        public Guid JobAppliedId { get; set; }
        public Job? Job { get; set; }

    }
}
