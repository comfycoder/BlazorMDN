using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.JSInterop;
using System.IO;
using System.Threading.Tasks;
using Westwind.AspNetCore.Markdown;

namespace BlazorMarkdown.Pages
{
    public partial class Post
    {
        [Inject]
        public IWebHostEnvironment Env { get; set; }

        [Inject]
        IJSRuntime jsRuntime { get; set; }

        public string FeaturedImage { get; set; }

        public string RawHtml { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var provider = Env.ContentRootFileProvider;
            var contents = provider.GetDirectoryContents(string.Empty);
            var filePath = Path.Combine("wwwroot", "posts", "markdown-monster", "markdown-monster.md");
            var fileInfo = provider.GetFileInfo(filePath);
            var markdownText = System.IO.File.ReadAllText(fileInfo.PhysicalPath);

            RawHtml = Markdown.Parse(markdownText);

            await base.OnInitializedAsync();
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await jsRuntime.InvokeVoidAsync("highlightInterop.highlightCode");
            }
        }
    }
}
