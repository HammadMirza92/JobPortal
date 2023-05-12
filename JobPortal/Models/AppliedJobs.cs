using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class AppliedJobs
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }
        [ForeignKey(nameof(JobId))]
        public Job? Job { get; set; }
        public int CandidateId { get; set; }
        [ForeignKey(nameof(CandidateId))]
        public Candidate? Candidate { get; set; }
    }
}
