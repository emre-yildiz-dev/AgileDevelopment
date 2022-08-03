using System.ComponentModel.DataAnnotations;

namespace AgileDevelopment.Models
{
    public class MindSet
    {
        public int MindSetID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        [Display(Name = "Member")]
        public int MemberID { get; set; }
        public Member? Member { get; set; }
    }
}
