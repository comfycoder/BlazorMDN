using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace ComfyPWA.BrowserLibrary
{
    public class PageMetadata
    {
        private const string JsFunctionsPrefix = "browserInterop";
        private readonly IJSRuntime _jsRuntime;

        public PageMetadata(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
        }

        public async Task SetPageTitle(string pageName, string siteName = null)
        {
            var title = siteName?.Length > 0 ? $"{pageName} - {siteName}" : pageName;

            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.setPageTitle", title);
        }

        public async Task AddMetaTagApplicationName(string content)
        {
            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "name", "application-name", content);
        }

        public async Task AddMetaTagAuthor(string content)
        {
            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "name", "author", content);
        }

        public async Task AddMetaTagDescription(string content)
        {
            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "name", "description", content);
        }

        public async Task AddMetaTagKeywords(string content)
        {
            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "name", "keywords", content);
        }

        public async Task AddMetaTagRobotsFollow(bool follow)
        {
            var content = follow ? "index, follow" : "noindex, nofollow";

            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "name", "robots", content);
        }

        public async Task RemoveMetaTag(string attribute, string value)
        {
            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.removeMetaTag", attribute, value);
        }

        // https://ahrefs.com/blog/open-graph-meta-tags/
        // https://ogp.me/

        public async Task AddMetaTagOgTitle(string pageTitle)
        {
            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "property", "og:title", pageTitle);
        }

        public async Task AddMetaTagOgUrl(string contentUrl)
        {
            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "property", "og:url", contentUrl);
        }

        public async Task AddMetaTagOgImage(string imageUrl)
        {
            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "property", "og:image", imageUrl);
        }

        public async Task AddMetaTagOgType(string type)
        {
            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "property", "og:type", type);
        }

        public async Task AddMetaTagOgDescription(string description)
        {
            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "property", "og:description", description);
        }

        public async Task AddMetaTagOgLocale(string locale)
        {
            await _jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "property", "og:locale", locale);
        }
    }
}

// https://moz.com/blog/meta-data-templates-123