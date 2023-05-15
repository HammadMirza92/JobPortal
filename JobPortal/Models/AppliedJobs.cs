using JobPortal.Models.ModelBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class AppliedJobs: BaseModel
    {

        public Guid JobsId { get; set; }
        [ForeignKey(nameof(JobsId))]
        public Job? Job { get; set; }
        public Guid CandidateId { get; set; }
        [ForeignKey(nameof(CandidateId))]
        public Candidate? Candidate { get; set; }
       /* public Guid EmployerId { get; set; }
        [ForeignKey(nameof(EmployerId))]
        public Employer? Employer { get; set; }*/
    }
}
