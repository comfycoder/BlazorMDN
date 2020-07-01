using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace ComfyPWA.Client.Pages
{
    public partial class Index
    {
        [Inject]
        ILogger<Index> Logger { get; set; }

        protected override void OnInitialized()
        {
            Logger.LogTrace("Log Trace");
            Logger.LogDebug("Log Debug");
            Logger.LogInformation("Log Information");
            Logger.LogWarning("Log Warning");
            Logger.LogError("Log Error");
        }
    }
}
