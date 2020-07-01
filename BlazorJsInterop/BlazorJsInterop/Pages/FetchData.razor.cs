using BlazorJsInterop.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorJsInterop.Pages
{
    public partial class FetchData
    {
        private WeatherForecast[] forecasts; 
        private const string JsFunctionsPrefix = "browserInterop";

        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        IJSRuntime jsRuntime { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }

        protected override async Task OnInitializedAsync()
        {
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");

            await jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.consoleTable", forecasts);
        }
    }
}
