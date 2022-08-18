using CodingChallenges.Services;

namespace CodingChallenges.Services
{
    public class RealExternalComponentService : IExternalComponentService
    {
        // does a real thing e.g.goes to a database or filesystem or network connection
        public List<string> GetStuff()
        {
            throw new NotImplementedException();
        }

    }
}
