using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorJsInterop.Shared
{
    public partial class PageMetadata
    {
        private const string JsFunctionsPrefix = "browserInterop";

        [Inject]
        IJSRuntime jsRuntime { get; set; }

        [Parameter]
        public string PageTitle { get; set; }

        [Parameter]
        public string ApplicationName { get; set; }

        [Parameter]
        public string Author { get; set; }

        [Parameter]
        public string Description { get; set; }

        [Parameter]
        public string Keywords { get; set; }

        [Parameter]
        public bool RobotsFollow { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await SetPageTitle();

            await AddMetaTagApplicationName();

            await AddMetaTagAuthor();

            await AddMetaTagDescription();

            await AddMetaTagKeywords();

            await AddMetaTagRobotsFollow();
        }

        public async Task SetPageTitle()
        {
            if (!string.IsNullOrWhiteSpace(ApplicationName) && !string.IsNullOrWhiteSpace(PageTitle))
            {
                await SetPageTitle($"{PageTitle} - {ApplicationName}");
            }
            else if (string.IsNullOrWhiteSpace(ApplicationName) && !string.IsNullOrWhiteSpace(PageTitle))
            {
                await SetPageTitle(PageTitle);
            }
        }

        public async Task AddMetaTagApplicationName()
        {
            if (!string.IsNullOrWhiteSpace(ApplicationName))
            {
                await AddMetaTagApplicationName(ApplicationName);
            }
            else
            {
                await RemoveMetaTag("name", "application-name");
            }
        }

        public async Task AddMetaTagAuthor()
        {

            if (!string.IsNullOrWhiteSpace(Author))
            {
                await AddMetaTagAuthor(Author);
            }
            else
            {
                await RemoveMetaTag("name", "author");
            }
        }

        public async Task AddMetaTagDescription()
        {
            if (!string.IsNullOrWhiteSpace(Description))
            {
                await AddMetaTagDescription(Description);
            }
            else
            {
                await RemoveMetaTag("name", "description");
            }
        }

        public async Task AddMetaTagKeywords()
        {
            if (!string.IsNullOrWhiteSpace(Keywords))
            {
                await AddMetaTagKeywords(Keywords);
            }
            else
            {
                await RemoveMetaTag("name", "keywords");
            }
        }

        public async Task AddMetaTagRobotsFollow()
        {
            await AddMetaTagRobotsFollow(RobotsFollow);
        }

        public async Task SetPageTitle(string pageName, string siteName = null)
        {
            var title = siteName?.Length > 0 ? $"{pageName} - {siteName}" : pageName;

            await jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.setPageTitle", title);
        }

        public async Task AddMetaTagApplicationName(string content)
        {
            await jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "name", "application-name", content);
        }

        public async Task AddMetaTagAuthor(string content)
        {
            await jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "name", "author", content);
        }

        public async Task AddMetaTagDescription(string content)
        {
            await jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "name", "description", content);
        }

        public async Task AddMetaTagKeywords(string content)
        {
            await jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "name", "keywords", content);
        }

        public async Task AddMetaTagRobotsFollow(bool follow)
        {
            var content = follow ? "index, follow" : "noindex, nofollow";

            await jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.addMetaTag", "name", "robots", content);
        }

        public async Task RemoveMetaTag(string attribute, string value)
        {
            await jsRuntime.InvokeVoidAsync($"{JsFunctionsPrefix}.removeMetaTag", attribute, value);
        }
    }
}
