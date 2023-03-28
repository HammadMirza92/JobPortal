using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryIcon { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
