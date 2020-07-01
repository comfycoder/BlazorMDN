using Microsoft.JSInterop;

namespace ComfyPWA.BrowserLibrary
{
    public class LocalBrowserStorage : BrowserStorage
    {
        public LocalBrowserStorage(IJSRuntime jsRuntime)
            : base("localStorage", jsRuntime)
        {
        }
    }
}
