using Microsoft.Extensions.DependencyInjection;

namespace ComfyPWA.BrowserLibrary
{
    public static class BrowserLibraryExtensions
    {
        public static void AddBrowserLibraryExtensions(this IServiceCollection services)
        {
            services.AddScoped<BrowserDialogs>();
            services.AddScoped<PageMetadata>();
            services.AddScoped<LocalBrowserStorage>();
            services.AddScoped<SessionBrowserStorage>();
        }
    }
}
