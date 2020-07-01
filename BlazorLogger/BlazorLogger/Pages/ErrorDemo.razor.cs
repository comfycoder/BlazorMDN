using BlazorLogger.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorLogger.Pages
{
    public partial  class ErrorDemo
    {
        private WeatherForecast[] forecasts;
        private bool loadFailed;

        [Inject]
        ILogger<ErrorDemo> Logger { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Logger.LogInformation("OnInitializedAsync");

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
