using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorJsInterop.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;
        private readonly static JsonSerializerOptions SerializerOptions = new JsonSerializerOptions();
        private const string JsFunctionsPrefix = "browserInterop";

        [Inject]
        ILogger<Counter> Logger { get; set; }

        [Inject]
        IJSRuntime jsRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            currentCount = await GetAsync<int>("currentCount");
            Logger.LogInformation("OnInitializedAsync: currentCount: " + currentCount);
        }

        private async Task IncrementCountAsync()
        {
            currentCount++;
            await SetAsync("currentCount", currentCount);
            Logger.LogInformation("IncrementCount: " + currentCount);
        }

        private async Task DecrementCountAsync()
        {
            currentCount--;
            await SetAsync("currentCount", currentCount);
            Logger.LogInformation("DecrementCount: " + currentCount);
        }

        private async Task ResetCountAsync()
        {
            currentCount = 0;
            await SetAsync("currentCount", currentCount);
            Logger.LogInformation("ResetCount: " + currentCount);
        }

        public ValueTask SetAsync<T>(string key, T value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot be null or empty", nameof(key));
            }

            var json = JsonSerializer.Serialize(value, options: SerializerOptions);

            return jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.set", "localStorage", key, json);
        }

        public async ValueTask<T> GetAsync<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot be null or empty", nameof(key));
            }

            var json = await jsRuntime.InvokeAsync<string>($"{JsFunctionsPrefix}.get", "localStorage", key);

            if (json == null)
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(json, options: SerializerOptions);
        }

        public ValueTask DeleteAsync(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot be null or empty", nameof(key));
            }

            return jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.delete", "localStorage", key);
        }
    }
}
