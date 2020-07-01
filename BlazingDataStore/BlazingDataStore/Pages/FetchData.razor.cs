using BlazingDataStore.Models;
using BlazingDataStore.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BlazingDataStore.Pages
{
    public partial class FetchData
    {
        protected WeatherForecast[] forecasts;

        [Inject]
        ILogger<FetchData> Logger { get; set; }

        [Inject]
        public WeatherForcastService WeatherForcastService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            forecasts = await WeatherForcastService.GetForecastAsync(DateTime.Now);

            Logger.LogJsonInformation("FetchData", forecasts);
        }
    }
}
