using Microsoft.AspNetCore.SignalR;
using RealTimeBlazorApp.Hubs;

namespace RealTimeBlazorApp.Services;

public class TaskUpdateService
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public TaskUpdateService( IHubContext<NotificationHub> hubContext )
    {
        _hubContext = hubContext;
    }

    public async Task NotifyTaskUpdatedAsync( string taskName, string status )
    {
        await _hubContext.Clients.All.SendAsync( "ReceiveChange", "Task Updated", $"{taskName} is now {status}" );
    }
}
