using JobPortal.Models.ModelBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    public class Skills: BaseModel
    {
        public string JobSkill { get; set; }
        public ICollection<JobSkills> JobSkills { get; set; }
        public ICollection<CandidateSkills> CandidateSkills { get; set; }
    }
}
