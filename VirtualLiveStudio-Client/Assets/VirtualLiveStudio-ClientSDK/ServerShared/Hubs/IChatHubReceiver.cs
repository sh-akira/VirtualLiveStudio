using VirtualLiveStudio.Shared.MessagePackObjects;

namespace VirtualLiveStudio.Shared.Hubs
{
    /// <summary>
    /// Server -> Client API
    /// </summary>
    public interface IChatHubReceiver
    {
        void OnJoin(string name);

        void OnLeave(string name);

        void OnSendMessage(ChatMessageResponse message);
    }
}
