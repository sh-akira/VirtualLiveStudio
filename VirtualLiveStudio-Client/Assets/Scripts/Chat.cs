using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtualLiveStudio;
using VirtualLiveStudio.Shared.MessagePackObjects;

public class Chat : MonoBehaviour
{
    private ChatHub chatHub = new ChatHub();

    private void Start()
    {
        chatHub.Connect();
        chatHub.OnJoinAction += ChatHub_OnJoin;
        chatHub.OnLeaveAction += ChatHub_OnLeave;
        chatHub.OnSendMessageEvent += ChatHub_OnSendMessage;
    }

    private async void OnDestroy() => await chatHub.DisposeAsync();

    private void ChatHub_OnJoin(string name) => messagelog += $"Join [{name}]\n";

    private void ChatHub_OnLeave(string name) => messagelog += $"Leave [{name}]\n";

    private void ChatHub_OnSendMessage(ChatMessageResponse message) => messagelog += $"{message.UserName} : {message.Message}\n";


    private string roomName = "Room Name";
    private string userName = "User Name";
    private string message = "MessageToSend";
    private string messagelog = "Received:\n";

    private void OnGUI()
    {
        roomName = GUI.TextField(new Rect(200, 10, 200, 24), roomName);
        userName = GUI.TextField(new Rect(400, 10, 200, 24), userName);
        if (GUI.Button(new Rect(600, 10, 100, 24), "Join")) join(roomName, userName);
        if (GUI.Button(new Rect(700, 10, 100, 24), "Leave")) leave();
        message = GUI.TextField(new Rect(200, 34, 500, 24), message);
        if (GUI.Button(new Rect(700, 34, 100, 24), "Send")) sendMessage(message);
        messagelog = GUI.TextArea(new Rect(200, 58, 600, 600), messagelog);
    }

    private async void join(string roomName, string userName) => await chatHub.JoinAsync(roomName, userName);

    private async void leave() => await chatHub.LeaveAsync();

    private async void sendMessage(string message) => await chatHub.SendMessageAsync(message);

}
