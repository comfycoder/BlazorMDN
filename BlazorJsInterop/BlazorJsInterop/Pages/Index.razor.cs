using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorJsInterop.Pages
{
    public partial class Index
    {
        private const string JsFunctionsPrefix = "browserInterop";

        private string promptResult;
        private string confirmResult;

        [Inject]
        ILogger<Index> Logger { get; set; }

        [Inject]
        IJSRuntime jsRuntime { get; set; }

        protected override void OnInitialized()
        {
            // await jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.consoleTable", forecasts);
        }

        private async Task ShowAlert()
        {
            var message = "You called the browser JavaScript alert function.";

            await jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.showAlert", message);
        }

        private async Task ShowPrompt()
        {
            var message = "Please enter your name.";

            promptResult = await jsRuntime.InvokeAsync<string>($"{JsFunctionsPrefix}.showPrompt", message);

            if (!string.IsNullOrWhiteSpace(promptResult))
            {
                promptResult = $"You entered '{promptResult}'";
            }
            else
            {
                promptResult = "You did not enter anything";
            }
        }

        private async Task ShowConfirm()
        {
            var message = "Please click one of these buttons.";

            var result = await jsRuntime.InvokeAsync<bool>($"{JsFunctionsPrefix}.showConfirm", message);

            if (result)
            {
                confirmResult = $"You chose 'OK'";
            }
            else
            {
                confirmResult = "You chose 'Cancel'";
            }
        }
    }
}
