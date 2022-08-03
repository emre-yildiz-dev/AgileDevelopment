using System.ComponentModel.DataAnnotations;

namespace AgileDevelopment.Models
{
    public class WiseSaying
    {
        public int WiseSayingID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Methodology")]
        public int MethodologyID { get; set; }
        public Methodology? Methodology { get; set; }
    }
}
