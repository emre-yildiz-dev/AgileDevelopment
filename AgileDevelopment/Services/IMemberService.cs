using AgileDevelopment.Models;

namespace AgileDevelopment.Services
{
    public interface IMemberService
    {
        public List<Member> FilterMemberById(int id, List<Member> members);
    }
}
