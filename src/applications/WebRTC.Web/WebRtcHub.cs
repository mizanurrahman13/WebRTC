using Microsoft.AspNetCore.SignalR;

public class WebRtcHub : Hub
{
    public async Task JoinMeeting(string meetingId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, meetingId);
        await Clients.OthersInGroup(meetingId).SendAsync("UserJoined", Context.ConnectionId);
    }

    public async Task LeaveMeeting(string meetingId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, meetingId);
        await Clients.OthersInGroup(meetingId).SendAsync("UserLeft", Context.ConnectionId);
    }

    public async Task SendSignal(string targetUserId, string signal)
    {
        await Clients.Client(targetUserId).SendAsync("ReceiveSignal", Context.ConnectionId, signal);
    }
}
