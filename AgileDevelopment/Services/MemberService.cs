using AgileDevelopment.Models;

namespace AgileDevelopment.Services
{
    public class MemberService: IMemberService
    {
        public List<Member> FilterMemberById(int id, List<Member> members)
        {
            var filteredMembers = members.Where(m => m.MethodologyID == id).ToList();
            return filteredMembers;
        }
    }
}
