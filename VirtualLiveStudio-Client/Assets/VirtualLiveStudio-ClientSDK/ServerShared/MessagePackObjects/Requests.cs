using MessagePack;

namespace VirtualLiveStudio.Shared.MessagePackObjects
{
    /// <summary>
    /// Room participation information
    /// </summary>
    [MessagePackObject]
    public struct ChatJoinRequest
    {
        [Key(0)]
        public string RoomName { get; set; }

        [Key(1)]
        public string UserName { get; set; }
    }
}