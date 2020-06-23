
using MagicOnion;
using MagicOnion.Server;
using System.Threading.Tasks;
using VirtualLiveStudio.Shared.Services;

namespace VirtualLiveStudio.Services
{
    public class TestService : ServiceBase<ITestService>, ITestService
    {
        public async UnaryResult<string> AskHello(string name) => $"Hello {name}!";
    }
}
