using AgileDevelopment.Models;
using AgileDevelopment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileDevelopment.Tests
{
    [TestFixture]
    public class ServiceTestClass
    {
        IMemberService memberService;
        IMindSetService mindSetService;

        [SetUp]
        public void Setup()
        {
            memberService = new MemberService();
            mindSetService = new MindSetService();
        }
        [Test]
        public void FilterMemberById_Works()
        {
            // Arrange
            var methodologyId = 1;
            var members = new List<Member>()
            {
                new Member{MemberID  =5, Title="Tester", MethodologyID = 1},
                new Member{MemberID = 6, Title="Manager", MethodologyID = 2},
                new Member{MemberID = 7, Title="Developer", MethodologyID = 1},
                new Member{MemberID = 8, Title="SysOps", MethodologyID = 1}
            };
            // Act
            var filteredMembers = memberService.FilterMemberById(methodologyId, members);

            // Assert
            Assert.That(filteredMembers, Is.EquivalentTo(members.Where(m => m.MethodologyID == methodologyId).ToList()));
            Assert.That(filteredMembers.Where(m => m.MemberID == 5).ToList()[0].Title, Is.EqualTo("Tester"));
        }

        [Test]
        public void FilterMindSetsByMemberIdAndMethodologyId_Works()
        {
            // Arrange
            var methodologyId = 2;
            var memberId = 1;
            var member1 = new Member { MethodologyID = 1, MemberID = 1, Title = "Tester" };
            var member2 = new Member { MethodologyID = 2, MemberID = 2, Title = "Programmer" };
            var mindSets = new List<MindSet>()
            {
                new MindSet { MindSetID = 1, Title = "whole-team approach", MemberID = 1, Member=member1 },
                new MindSet { MindSetID = 2, Title = "adopt agile testing mind-set", MemberID = 2, Member=member2 },
                new MindSet { MindSetID = 3, Title = "automate regression testing", MemberID = 2, Member=member1 },
                new MindSet { MindSetID = 4, Title = "provide and obtain feedback", MemberID = 1 , Member = member1},
                new MindSet { MindSetID = 5, Title = "collabrate with customers", MemberID = 1 , Member = member1},
                new MindSet { MindSetID = 5, Title = "Build collabration practices", MemberID = 1,  Member=member2 },
            };

            // Act
            var filteredMindSets = mindSetService.FilterMindSetsByMemberId(memberId, mindSets);

            // Assert
            Assert.That(filteredMindSets, Is.EqualTo(mindSets.Where(ms => ms.MemberID == memberId).ToList()));


        }
    }
}
