using AgileDevelopment.Models;

namespace AgileDevelopment.Services
{
    public class MindSetService : IMindSetService
    {
        public List<MindSet> FilterMindSetsByMemberId(int memberId, List<MindSet> mindSets)
        {
            return mindSets.Where(ms => ms.MemberID == memberId).ToList();
        }
    }
}
