using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace ComfyPWA.BrowserLibrary
{
    public class BrowserDialogs
    {
        private const string JsFunctionsPrefix = "browserInterop";
        private readonly IJSRuntime _jsRuntime;

        public BrowserDialogs(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
        }

        public async Task ShowAlert(string message)
        {
            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.showAlert", message);
        }

        public async Task ShowPrompt(string message, string defaultValue)
        {
            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.showPrompt", message, defaultValue);
        }
    }
}
