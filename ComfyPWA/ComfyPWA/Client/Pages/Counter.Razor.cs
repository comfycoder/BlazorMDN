using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfyPWA.Client.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;

        [Inject]
        ILogger<Counter> Logger { get; set; }

        [Inject]
        ILocalStorageService LocalStorage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            currentCount = await LocalStorage.GetItemAsync<int>("currentCount");
            Logger.LogInformation("OnInitializedAsync: currentCount: " + currentCount);
        }

        private async Task IncrementCountAsync()
        {
            currentCount++;
            await LocalStorage.SetItemAsync("currentCount", currentCount);
            Logger.LogInformation("IncrementCount: " + currentCount);
        }

        private async Task DecrementCountAsync()
        {
            currentCount--;
            await LocalStorage.SetItemAsync("currentCount", currentCount);
            Logger.LogInformation("DecrementCount: " + currentCount);
        }

        private async Task ResetCountAsync()
        {
            currentCount = 0;
            await LocalStorage.SetItemAsync("currentCount", currentCount);
            Logger.LogInformation("ResetCount: " + currentCount);
        }
    }
}
