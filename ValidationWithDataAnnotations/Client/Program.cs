using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ValidationWithDataAnnotations;

namespace Company.WebApplication1
{
    public class Program
    {
        public static async Task Main( string[] args )
        {
            var builder = WebAssemblyHostBuilder.CreateDefault( args );
            builder.RootComponents.Add<App>( "#app" );
            builder.RootComponents.Add<HeadOutlet>( "head::after" );

            builder.Services.AddScoped( sp => new HttpClient { BaseAddress = new Uri( builder.HostEnvironment.BaseAddress ) } );

            builder.Services
                .AddBlazorise( options =>
                {
                    options.Immediate = true;
                } )
                .AddBootstrap5Providers()
                .AddFontAwesomeIcons();

            await builder.Build().RunAsync();
        }
    }
}