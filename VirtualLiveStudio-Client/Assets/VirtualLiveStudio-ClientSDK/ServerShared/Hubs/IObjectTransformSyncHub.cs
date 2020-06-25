using MagicOnion;
using System.Threading.Tasks;
using VirtualLiveStudio.Shared.MessagePackObjects;

namespace VirtualLiveStudio.Shared.Hubs
{
    /// <summary>
    /// Client -> Server API (Streaming)
    /// </summary>
    public interface IObjectTransformSyncHub : IStreamingHub<IObjectTransformSyncHub, IObjectTransformSyncHubReceiver>
    {
        Task<SyncObjectTransform> RegisterAsync(string name);

        Task UnregisterAsync();

        Task SendTransformAsync(SyncObjectTransform syncObjectTransform);
    }
}