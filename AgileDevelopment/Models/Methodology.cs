using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgileDevelopment.Models
{
    public class Methodology
    {
        public int MethodologyID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public ICollection<Member>? Members { get; set; }
        public ICollection<Principle>? Principles { get; set; }
        public ICollection<MethodFramework>? MethodFrameworks { get; set; }
        public ICollection<Practice>? Practices { get; set; }
        public ICollection<Test>? Tests { get; set; }
        public ICollection<WiseSaying>? WiseSayings { get; set; }
    }
}
