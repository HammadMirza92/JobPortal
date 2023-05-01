using JobPortal.Enums;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileImg{ get; set; }
        public string AboutMe{ get; set; }
        public string Experience { get; set; }
        public int Phone { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        public int ExperienceTime { get; set; }
        public int ExpectedSalary { get; set; }
        public int Age { get; set; }
        public Qualification Qualification { get; set; }

        public ICollection<CandidateSkills> CandidateSkills { get; set; }
    }
}
