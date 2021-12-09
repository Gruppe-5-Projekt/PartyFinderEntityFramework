using PartyFinderData.DatabaseLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace APIUnitTest
{
    internal class MatchAccessTest
    {
        private readonly ITestOutputHelper extraOutput;
        readonly private IMatchAccess _eventAccess;
        public MatchAccessTest(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _eventAccess = new MatchAccess();
        }
    }
}
