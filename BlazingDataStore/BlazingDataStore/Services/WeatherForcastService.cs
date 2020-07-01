using BlazingDataStore.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazingDataStore.Services
{
    public class WeatherForcastService
    {

        private IConfiguration _config;
        private ILogger<WeatherForcastService> _logger;
        private HttpClient _http;
        public bool LogVerbose { get; set; }

        public WeatherForcastService(IConfiguration config, IWebAssemblyHostEnvironment env, ILogger<WeatherForcastService> logger, HttpClient http)
        {
            _config = config;
            _logger = logger;
            _http = http;
            _http.BaseAddress = new Uri(env.BaseAddress);
            _logger.LogInformation("Create StarWarsPeopleService");
        }

        public string GetBaseApiUrl()
        {
            var url = _config["starWarsApi"];
            _logger.LogInformation($"Star Wars API: {url}");
            return url;
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime dateTime)
        {
            WeatherForecast[] response = await _http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");

            if (LogVerbose)
            {
                var json = JsonSerializer.Serialize<WeatherForecast[]>(response, new JsonSerializerOptions { WriteIndented = true });
                _logger.LogInformation($"PeopleResponse: {json}");
            }

            return response;
        }
    }
}
