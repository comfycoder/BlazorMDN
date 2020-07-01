using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ComfyPWA.Client
{
    public partial class App: IDisposable
    {
        [Inject]
        ILogger<App> Logger { get; set; }

        [Inject]
        ILocalStorageService LocalStorage { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }

        protected override Task OnInitializedAsync()
        {
            Logger.LogInformation("Initializing App...");

            Navigation.LocationChanged += Navigation_LocationChanged;

            return base.OnInitializedAsync();
        }

        private void Navigation_LocationChanged(object sender, Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs e)
        {
            Logger.LogInformation($"Navigation Location Changed: {e.Location}");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Navigation.LocationChanged -= Navigation_LocationChanged;
            }
        }    
    }
}
