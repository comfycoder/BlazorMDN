using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLogger.Pages
{
    public partial class Counter
    {
        [Inject]
        ILogger<Counter> Logger { get; set; }

        private int currentCount = 0;

        protected override async Task OnInitializedAsync()
        {
            Logger.LogInformation("OnInitializedAsync");
        }

        private void IncrementCount()
        {
            currentCount++;
            Logger.LogInformation("IncrementCount: " + currentCount);
        }
    }
}
