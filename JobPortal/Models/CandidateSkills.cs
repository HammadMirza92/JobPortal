using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class CandidateSkills
    {
        [Key]
        public int Id { get; set; }
        public int CandidateId { get; set; }
        [ForeignKey(nameof(CandidateId))]
        public Candidate Candidate { get; set; }
        public int SkillId { get; set; }
        [ForeignKey(nameof(SkillId))]
        public Skills Skills { get; set; }
    }
}
