using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace ComfyPWA.BrowserLibrary
{
    public class BrowserStorage
    {
        private const string JsFunctionsPrefix = "browserInterop";
        private readonly string _storeName;
        private readonly IJSRuntime _jsRuntime;
        private readonly static JsonSerializerOptions SerializerOptions = new JsonSerializerOptions();

        protected BrowserStorage(string storeName, IJSRuntime jsRuntime)
        {
            if (string.IsNullOrEmpty(storeName))
            {
                throw new ArgumentException("The value cannot be null or empty", nameof(storeName));
            }

            _storeName = storeName;
            _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
        }

        public ValueTask SetAsync<T>(string key, T value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot be null or empty", nameof(key));
            }

            var json = JsonSerializer.Serialize(value, options: SerializerOptions);

            return _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.set", _storeName, key, json);
        }

        public async ValueTask<T> GetAsync<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Cannot be null or empty", nameof(key));
            }

            var json = await _jsRuntime.InvokeAsync<string>($"{JsFunctionsPrefix}.get", _storeName, key);

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

            return _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.delete", _storeName, key);
        }
    }
}
