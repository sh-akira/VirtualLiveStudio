using MessagePack;

namespace VirtualLiveStudio.Shared.MessagePackObjects
{
    /// <summary>
    /// Chat Message information
    /// </summary>
    [MessagePackObject]
    public struct ChatMessageResponse
    {
        [Key(0)]
        public string UserName { get; set; }

        [Key(1)]
        public string Message { get; set; }
    }
}