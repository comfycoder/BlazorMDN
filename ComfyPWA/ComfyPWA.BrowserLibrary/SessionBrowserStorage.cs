using Microsoft.JSInterop;

namespace ComfyPWA.BrowserLibrary
{
    public class SessionBrowserStorage : BrowserStorage
    {
        public SessionBrowserStorage(IJSRuntime jsRuntime)
            : base("sessionStorage", jsRuntime)
        {
        }
    }
}
