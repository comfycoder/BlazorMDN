using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorLogger.Pages
{
    public partial class Index
    {
        [Inject]
        ILogger<Index> Logger { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Logger.LogTrace("Log Trace");
            Logger.LogDebug("Log Debug");
            Logger.LogInformation("Log Information");
            Logger.LogWarning("Log Warning");
            Logger.LogError("Log Error");
        }
    }
}
