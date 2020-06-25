using MagicOnion.Client;
using System;
using System.Threading.Tasks;
using UnityEngine;
using VirtualLiveStudio.Shared.Hubs;
using VirtualLiveStudio.Shared.MessagePackObjects;

namespace VirtualLiveStudio
{
    public class ObjectTransformSyncHub : IObjectTransformSyncHubReceiver
    {
        public event Action<SyncObjectTransform> OnSendTransformEvent;

        private IObjectTransformSyncHub objectTransformHub;

        public void Connect() => objectTransformHub = StreamingHubClient.Connect<IObjectTransformSyncHub, IObjectTransformSyncHubReceiver>(VirtualLiveStudioCore.GrpcChannel, this);

        public async Task DisposeAsync() => await objectTransformHub.DisposeAsync();


        // Client -> Server impl
        public async Task RegisterAsync(string name)
        {
            var syncObjectTransform = await objectTransformHub.RegisterAsync(name);
            OnSendTransformEvent?.Invoke(syncObjectTransform);
        }

        public Task SendTransformAsync(SyncObjectTransform syncObjectTransform) => objectTransformHub.SendTransformAsync(syncObjectTransform);

        public Task UnregisterAsync() => objectTransformHub.UnregisterAsync();

        //Server -> Client impl
        void IObjectTransformSyncHubReceiver.OnSendTransform(SyncObjectTransform syncObjectTransform) => OnSendTransformEvent?.Invoke(syncObjectTransform);
    }
}
