using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazingDataStore.State;
using BlazingDataStore.Services;

namespace BlazingDataStore
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            IConfiguration config = builder.Configuration;

            IWebAssemblyHostEnvironment env = builder.HostEnvironment;

            builder.Logging.Services.AddLogging(logger => {
                logger.SetMinimumLevel(LogLevel.Trace);
            });

            builder.Services.AddSingleton<AppState>();

            builder.Services.AddTransient<HttpClient>();

            builder.Services.AddTransient<WeatherForcastService>();

            builder.Services.AddTransient<StarWarsPeopleService>();

            builder.RootComponents.Add<App>("app");

            var host = builder.Build();

            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            logger.LogInformation("Starting Program...");

            await builder.Build().RunAsync();
        }
    }
}
