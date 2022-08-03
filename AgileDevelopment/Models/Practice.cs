using System.ComponentModel.DataAnnotations;

namespace AgileDevelopment.Models
{
    public class Practice
    {
        public int PracticeID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        [Display(Name = "Methodology")]
        public int MethodologyID { get; set; }
        public Methodology? Methodology { get; set; }
    }
}
