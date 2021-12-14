using PartyFinderData.DatabaseLayers;
using PartyFinderData.ModelLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace APIUnitTest
{
    public class MatchAccessTest
    {
        private readonly ITestOutputHelper extraOutput;
        readonly private IMatchAccess _matchAccess;
        readonly private IEventAccess _eventAccess;
        public MatchAccessTest(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _matchAccess = new MatchAccess();
            _eventAccess = new EventAccess();

        }

        //[Fact]
        //public void CheckAndCommitMatchTest()
        //{
        //    // Arrange

        //    Event testEvent = new Event("Test", 5, new DateTime(2008, 5, 1, 8, 30, 52), new DateTime(2009, 5, 1, 8, 30, 52), "Test", 1);
        //    // Act


        //    _eventAccess.DeleteEvent(testEvent);
        //}
    }
}
