using Microsoft.AspNetCore.SignalR;

namespace WebRTC.Infrastructure;

public class VideoChatHub : Hub
{
    private static Dictionary<string, string> userRoomMap = new Dictionary<string, string>();

    public async Task JoinRoom(string roomName)
    {
        string connectionId = Context.ConnectionId;

        // Leave the existing room, if any
        if (userRoomMap.ContainsKey(connectionId))
        {
            string oldRoom = userRoomMap[connectionId];
            await Groups.RemoveFromGroupAsync(connectionId, oldRoom);
            userRoomMap.Remove(connectionId);
        }

        // Join the new room
        await Groups.AddToGroupAsync(connectionId, roomName);
        userRoomMap[connectionId] = roomName;

        await Clients.Group(roomName).SendAsync("UserJoined", connectionId);
    }

    public async Task SendSignal(string signalData)
    {
        await Clients.OthersInGroup(userRoomMap[Context.ConnectionId]).SendAsync("ReceiveSignal", Context.ConnectionId, signalData);
    }
}


