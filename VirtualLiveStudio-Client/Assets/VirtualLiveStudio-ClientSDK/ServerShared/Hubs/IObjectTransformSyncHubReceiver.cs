using VirtualLiveStudio.Shared.MessagePackObjects;

namespace VirtualLiveStudio.Shared.Hubs
{
    /// <summary>
    /// Server -> Client API
    /// </summary>
    public interface IObjectTransformSyncHubReceiver
    {
        void OnSendTransform(SyncObjectTransform syncObjectTransform);
    }
}
