using JobPortal.Models.ModelBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class CandidateSkills: BaseModel
    {
        public Guid CandidateId { get; set; }
        [ForeignKey(nameof(CandidateId))]
        public Candidate Candidate { get; set; }
        public Guid SkillId { get; set; }
        [ForeignKey(nameof(SkillId))]
        public Skills Skills { get; set; }
    }
}
