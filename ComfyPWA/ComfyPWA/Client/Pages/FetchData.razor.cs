using Blazored.LocalStorage;
using ComfyPWA.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ComfyPWA.Client.Pages
{
    public partial class FetchData
    {
        private WeatherForecast[] forecasts;

        [Inject]
        ILogger<Index> Logger { get; set; }

        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }

        [Inject]
        ILocalStorageService LocalStorage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var savedToken = await LocalStorage.GetItemAsync<string>("authToken");
            Http.DefaultRequestHeaders.Add("Authorization", $"Bearer {savedToken}");
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
            Logger.LogJsonInformation("forcasts", forecasts);
        }
    }
}
