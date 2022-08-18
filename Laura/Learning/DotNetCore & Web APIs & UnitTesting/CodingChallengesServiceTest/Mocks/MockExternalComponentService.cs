using CodingChallenges.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace CodingChallenges.Test.Mocks
{
    public class MockExternalComponentService : IExternalComponentService
    {
        // not real - only does hard coded things
         public List<string> GetStuff() => new List<string>();

       
    }
}
