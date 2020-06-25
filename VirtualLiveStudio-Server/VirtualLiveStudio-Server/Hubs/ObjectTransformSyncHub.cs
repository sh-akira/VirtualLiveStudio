using MagicOnion.Server.Hubs;
using System.Threading.Tasks;
using VirtualLiveStudio.Shared.Hubs;
using VirtualLiveStudio.Shared.MessagePackObjects;

namespace VirtualLiveStudio.Hubs
{
    /// <summary>
    /// Object Transform Sync server processing.
    /// One class instance for one connection.
    /// </summary>
    public class ObjectTransformSyncHub : StreamingHubBase<IObjectTransformSyncHub, IObjectTransformSyncHubReceiver>, IObjectTransformSyncHub
    {
        private IGroup room;
        private SyncObjectTransform currentSyncObjectTransform;

        public async Task<SyncObjectTransform> RegisterAsync(string name)
        {
            room = await Group.AddAsync(name);
            return currentSyncObjectTransform;
        }

        public async Task SendTransformAsync(SyncObjectTransform syncObjectTransform)
        {
            currentSyncObjectTransform = syncObjectTransform;
            Broadcast(room).OnSendTransform(syncObjectTransform);
        }

        public async Task UnregisterAsync()
        {
            await room.RemoveAsync(Context);
        }

        protected override ValueTask OnDisconnected()
        {
            // handle disconnection if needed.
            // on disconnecting, if automatically removed this connection from group.
            return CompletedTask;
        }
    }
}
