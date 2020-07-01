using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorLogger.Pages
{
    public partial class Lifecycle
    {
        [Inject]
        ILogger<Lifecycle> Logger { get; set; }

        public IList<string> Messages { get; set; } = new List<string>();

        protected override void OnInitialized()
        {
            Logger.LogInformation("OnInitialized");

            Messages.Add("OnInitialized");

            base.OnInitialized();
        }

        protected override Task OnInitializedAsync()
        {
            Logger.LogInformation("OnInitializedAsync");

            Messages.Add("OnInitializedAsync");

            return base.OnInitializedAsync();
        }

        protected override void OnParametersSet()
        {
            Logger.LogInformation("OnParametersSet");

            Messages.Add("OnParametersSet");

            base.OnParametersSet();
        }

        protected override Task OnParametersSetAsync()
        {
            Logger.LogInformation("OnParametersSetAsync");

            Messages.Add("OnParametersSetAsync");

            return base.OnParametersSetAsync();
        }

        protected override bool ShouldRender()
        {
            Logger.LogInformation("ShouldRender");

            Messages.Add("ShouldRender");

            return base.ShouldRender();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            Logger.LogInformation("OnAfterRender");

            Messages.Add("OnAfterRender");

            if (firstRender)
            {
                Logger.LogInformation("OnAfterRender: firstRender");

                Messages.Add("OnAfterRender: firstRender");
            }

            base.OnAfterRender(firstRender);
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            Logger.LogInformation("OnAfterRenderAsync");

            Messages.Add("OnAfterRenderAsync");

            if (firstRender)
            {
                Logger.LogInformation("OnAfterRenderAsync: firstRender");

                Messages.Add("OnAfterRenderAsync: firstRender");
            }

            return base.OnAfterRenderAsync(firstRender);
        }
    }
}
