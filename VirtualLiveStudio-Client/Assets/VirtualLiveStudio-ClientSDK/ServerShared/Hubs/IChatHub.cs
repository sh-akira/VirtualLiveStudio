using MagicOnion;
using System.Threading.Tasks;
using VirtualLiveStudio.Shared.MessagePackObjects;

namespace VirtualLiveStudio.Shared.Hubs
{
    /// <summary>
    /// Client -> Server API (Streaming)
    /// </summary>
    public interface IChatHub : IStreamingHub<IChatHub, IChatHubReceiver>
    {
        Task JoinAsync(ChatJoinRequest request);

        Task LeaveAsync();

        Task SendMessageAsync(string message);
    }
}