using BlazingDataStore.Models;
using BlazingDataStore.State;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazingDataStore.Services
{
    public class StarWarsPeopleService
    {
        private IConfiguration _config;
        private ILogger<StarWarsPeopleService> _logger;
        private HttpClient _http;
        private AppState _appState;
        public bool LogVerbose { get; set; }

        public StarWarsPeopleService(IConfiguration config, ILogger<StarWarsPeopleService> logger, AppState appState, HttpClient http)
        {
            _config = config;
            _logger = logger;
            _http = http;
            _appState = appState;
            _logger.LogInformation("Create StarWarsPeopleService");
        }

        public string GetBaseApiUrl()
        {
            var url = _config["starWarsApi"];
            _logger.LogInformation($"Star Wars API: {url}");
            return url;
        }

        public async Task<PeopleResponse> GetPeople(string url = null)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                url = url.Replace("http:", "https:");
            }
            else
            {
                var baseUrl = GetBaseApiUrl();
                url = $"{baseUrl}people";
            }

            _logger.LogInformation($"Star Wars People API: {url}");

            PeopleResponse response = await _http.GetFromJsonAsync<PeopleResponse>(url);

            if (LogVerbose)
            {
                var json = JsonSerializer.Serialize<PeopleResponse>(response, new JsonSerializerOptions { WriteIndented = true });
                _logger.LogInformation($"PeopleResponse: {json}");
            }

            _appState.PersonStore.SetPeopleResponse(response);

            return response;
        }
    }
}
