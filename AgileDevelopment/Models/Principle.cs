using System.ComponentModel.DataAnnotations;

namespace AgileDevelopment.Models
{
    public class Principle
    {
        public int PrincipleID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        [Display(Name = "Methodology")]
        public int MethodologyID { get; set; }
        
    }
}
