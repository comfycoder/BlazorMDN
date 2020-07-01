using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ComfyPWA.Client.Common;
using ComfyPWA.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ComfyPWA.BrowserLibrary;

namespace ComfyPWA.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            IConfiguration config = builder.Configuration;

            IWebAssemblyHostEnvironment env = builder.HostEnvironment;

            builder.Logging.SetMinimumLevel(LogLevel.Trace).AddFilter("Microsoft", LogLevel.Warning);

            builder.Logging.Services.AddLogging();

            var host = builder.Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            logger.LogInformation("Starting Program...");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //----------------------------------------------------------------------
            // Added for Custom Authentication
            //----------------------------------------------------------------------
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            //----------------------------------------------------------------------

            builder.Services.AddBrowserLibraryExtensions();

            await builder.Build().RunAsync();
        }
    }
}
