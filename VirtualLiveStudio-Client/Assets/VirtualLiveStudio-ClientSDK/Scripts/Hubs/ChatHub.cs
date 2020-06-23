using MagicOnion.Client;
using System;
using System.Threading.Tasks;
using UnityEngine;
using VirtualLiveStudio.Shared.Hubs;
using VirtualLiveStudio.Shared.MessagePackObjects;

namespace VirtualLiveStudio
{
    public class ChatHub : IChatHubReceiver
    {
        public event Action<string> OnJoinAction;
        public event Action<string> OnLeaveAction;
        public event Action<ChatMessageResponse> OnSendMessageEvent;

        private IChatHub chatHub;

        public void Connect() => chatHub = StreamingHubClient.Connect<IChatHub, IChatHubReceiver>(VirtualLiveStudioCore.GrpcChannel, this);

        public async Task DisposeAsync() => await chatHub.DisposeAsync();


        // Client -> Server impl
        public async Task JoinAsync(string roomName, string userName) => await chatHub.JoinAsync(new ChatJoinRequest { RoomName = roomName, UserName = userName });

        public async Task LeaveAsync() => await chatHub.LeaveAsync();

        public async Task SendMessageAsync(string message) => await chatHub.SendMessageAsync(message);

        //Server -> Client impl
        void IChatHubReceiver.OnJoin(string name) => OnJoinAction?.Invoke(name);

        void IChatHubReceiver.OnLeave(string name) => OnLeaveAction?.Invoke(name);

        void IChatHubReceiver.OnSendMessage(ChatMessageResponse message) => OnSendMessageEvent?.Invoke(message);

    }
}
