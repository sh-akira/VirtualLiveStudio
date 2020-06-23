
using MagicOnion;
using MagicOnion.Server;
using System.Threading.Tasks;
using VirtualLiveStudio.Shared.Services;

namespace VirtualLiveStudio.Services
{
    // implement RPC service to Server Project.
    // inehrit ServiceBase<interface>, interface
    public class TestService : ServiceBase<ITestService>, ITestService
    {
        // You can use async syntax directly.
        public async UnaryResult<string> AskHello(string name)
        {
            return $"Hello {name}!";
        }

    }
}
