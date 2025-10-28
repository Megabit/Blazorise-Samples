using Microsoft.AspNetCore.SignalR;
using RealTimeBlazorApp.Hubs;

namespace RealTimeBlazorApp.Services;

public class DashboardUpdateService : BackgroundService
{
    private readonly IHubContext<NotificationHub> _hub;

    public DashboardUpdateService( IHubContext<NotificationHub> hub )
    {
        _hub = hub;
    }

    protected override async Task ExecuteAsync( CancellationToken stoppingToken )
    {
        var rand = new Random();

        while ( !stoppingToken.IsCancellationRequested )
        {
            var cpu = rand.Next( 10, 90 );
            var mem = rand.Next( 20, 80 );
            await _hub.Clients.All.SendAsync( "ReceiveChange", "System Metrics", $"CPU: {cpu}%, Memory: {mem}%" );
            await Task.Delay( 3000, stoppingToken );
        }
    }
}