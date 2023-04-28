using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Skills
    {
        [Key]
        public int Id { get; set; }
        public string JobSkill { get; set; }
        public ICollection<JobSkills> JobSkills { get; set; }
    }
}
