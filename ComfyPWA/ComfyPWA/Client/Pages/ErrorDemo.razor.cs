using ComfyPWA.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ComfyPWA.Client.Pages
{
    public partial class ErrorDemo
    {
        public WeatherForecast[] forecasts;
        public bool loadFailed;

        [Inject]
         ILogger<ErrorDemo> Logger { get; set; }

        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        IWebAssemblyHostEnvironment Env { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Logger.LogInformation("OnInitializedAsync");

            Logger.LogInformation("Environment: " + (Env.IsDevelopment() ? "Development" : "Production"));

            try
            {
                loadFailed = false;

                forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data-bad/weather.json");

                Logger.LogJsonInformation("OnInitializedAsync: forcasts", forecasts);
            }
            catch (Exception ex)
            {
                loadFailed = true;

                Logger.LogError(ex, "Failed to load weather forcasts");
            }
        }

        private void LogCriticalError()
        {
            Logger.LogCritical("LogCriticalError: Throw critical error");
        }
    }
}
