using CodingChallenges.Services;

namespace CodingChallenges.Services
{
    public class SecondRealExternalComponentService : IExternalComponentService
    {
        // does a real thing e.g.goes to a database or filesystem or network connection
        public List<string> GetStuff()
        {
            // this can do completely different stuff to the RealExternalComponentsService
            throw new NotImplementedException();
        }

    }
}
