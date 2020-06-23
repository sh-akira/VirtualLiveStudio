using System.Threading.Tasks;

namespace VirtualLiveStudio
{
    public class TestService
    {
        public string Name = "TestName";
        public async Task<string> AskHello() => await VirtualLiveStudioCore.TestService.AskHello(Name);

    }
}