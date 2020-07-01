using ComfyPWA.BrowserLibrary;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ComfyPWA.BrowserLibrary
{
    public partial class PageMeta
    {
        [Inject]
        public PageMetadata Meta { get; set; }

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
                await Meta.SetPageTitle($"{PageTitle} - {ApplicationName}");
            }
            else if (string.IsNullOrWhiteSpace(ApplicationName) && !string.IsNullOrWhiteSpace(PageTitle))
            {
                await Meta.SetPageTitle(PageTitle);
            }
        }

        public async Task AddMetaTagApplicationName()
        {
            if (!string.IsNullOrWhiteSpace(ApplicationName))
            {
                await Meta.AddMetaTagApplicationName(ApplicationName);
            }
            else
            {
                await Meta.RemoveMetaTag("name", "application-name");
            }
        }

        public async Task AddMetaTagAuthor()
        {

            if (!string.IsNullOrWhiteSpace(Author))
            {
                await Meta.AddMetaTagAuthor(Author);
            }
            else
            {
                await Meta.RemoveMetaTag("name", "author");
            }
        }

        public async Task AddMetaTagDescription()
        {
            if (!string.IsNullOrWhiteSpace(Description))
            {
                await Meta.AddMetaTagDescription(Description);
            }
            else
            {
                await Meta.RemoveMetaTag("name", "description");
            }
        }

        public async Task AddMetaTagKeywords()
        {
            if (!string.IsNullOrWhiteSpace(Keywords))
            {
                await Meta.AddMetaTagKeywords(Keywords);
            }
            else
            {
                await Meta.RemoveMetaTag("name", "keywords");
            }
        }

        public async Task AddMetaTagRobotsFollow()
        {
            await Meta.AddMetaTagRobotsFollow(RobotsFollow);
        }
    }
}
