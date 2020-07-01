using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLogger
{
    public partial class App
    {
        [Inject]
        ILogger<App> Logger { get; set; }

        protected override Task OnInitializedAsync()
        {
            Logger.LogInformation("Initializing App...");

            return base.OnInitializedAsync();
        }
    }
}
