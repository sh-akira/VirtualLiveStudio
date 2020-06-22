using MagicOnion;
using System.Threading.Tasks;

namespace VirtualLiveStudio.Interfaces
{
    // define interface as Server/Client IDL.
    // implements T : IService<T> and share this type between server and client.
    public interface ITestService : IService<ITestService>
    {
        // Return type must be `UnaryResult<T>` or `Task<UnaryResult<T>>`.
        // If you can use C# 7.0 or newer, recommend to use `UnaryResult<T>`.
        UnaryResult<string> AskHello(string name);
    }
}
