using MagicOnion.Server.Hubs;
using System.Threading.Tasks;
using VirtualLiveStudio.Shared.Hubs;
using VirtualLiveStudio.Shared.MessagePackObjects;

namespace VirtualLiveStudio.Hubs
{
    /// <summary>
    /// Chat server processing.
    /// One class instance for one connection.
    /// </summary>
    public class ChatHub : StreamingHubBase<IChatHub, IChatHubReceiver>, IChatHub
    {
        private IGroup room;
        private string myName;

        public async Task JoinAsync(ChatJoinRequest request)
        {
            room = await Group.AddAsync(request.RoomName);

            myName = request.UserName;

            Broadcast(room).OnJoin(request.UserName);
        }


        public async Task LeaveAsync()
        {
            await room.RemoveAsync(Context);

            Broadcast(room).OnLeave(myName);
        }

        public async Task SendMessageAsync(string message)
        {
            var response = new ChatMessageResponse { UserName = myName, Message = message };
            Broadcast(room).OnSendMessage(response);

            await Task.CompletedTask;
        }
        
        protected override ValueTask OnDisconnected()
        {
            // handle disconnection if needed.
            // on disconnecting, if automatically removed this connection from group.
            return CompletedTask;
        }
    }
}
