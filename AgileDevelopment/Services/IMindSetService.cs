using AgileDevelopment.Models;

namespace AgileDevelopment.Services
{
    public interface IMindSetService
    {
        public List<MindSet> FilterMindSetsByMemberId(int memberId, List<MindSet> mindSets);
    }
}
