using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.ResponseCompression;
using RealTimeBlazorApp.Components;
using RealTimeBlazorApp.Hubs;
using RealTimeBlazorApp.Services;

namespace RealTimeBlazorApp;

public class Program
{
    public static void Main( string[] args )
    {
        var builder = WebApplication.CreateBuilder( args );

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // Add SignalR
        builder.Services.AddSignalR();

        builder.Services.AddResponseCompression( opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                ["application/octet-stream"] );
        } );

        builder.Services
            .AddBlazorise( options =>
            {
                options.Immediate = true;
            } )
            .AddBootstrap5Providers()
            .AddFontAwesomeIcons();

        builder.Services.AddSingleton<TaskUpdateService>();
        builder.Services.AddHostedService<DashboardUpdateService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if ( !app.Environment.IsDevelopment() )
        {
            app.UseExceptionHandler( "/Error" );
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.UseResponseCompression();
        app.MapHub<NotificationHub>( "/notificationHub" );

        app.Run();
    }
}
