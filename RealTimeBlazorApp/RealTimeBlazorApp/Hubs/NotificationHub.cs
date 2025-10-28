using Microsoft.AspNetCore.SignalR;

namespace RealTimeBlazorApp.Hubs;

public interface INotificationsClient
{
    Task ReceiveMessage( string user, string message );
    Task ReceiveChange( string title, string content );
}

public class NotificationHub : Hub<INotificationsClient>
{
    public Task SendMessage( string user, string message )
        => Clients.All.ReceiveMessage( user, message );

    public Task NotifyChange( string title, string content )
        => Clients.All.ReceiveChange( title, content );
}