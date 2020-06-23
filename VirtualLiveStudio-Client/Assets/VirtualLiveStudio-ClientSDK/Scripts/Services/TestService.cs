using System.Threading.Tasks;

namespace VirtualLiveStudio
{
    public class TestService
    {
        public string Name = "TestName";
        public async Task<string> AskHello()
        {
            return await VirtualLiveStudioCore.TestService.AskHello(Name);
        }
    }
}