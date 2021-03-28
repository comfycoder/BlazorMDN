using Markdig;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorMarkdownWasm.Pages
{
    public partial class Post
    {

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        IJSRuntime jsRuntime { get; set; }

        public string RawHtml { get; set; }

        protected async override Task OnInitializedAsync()
        {
            // var response = await Http.GetStringAsync("posts/markdown-monster/markdown-monster.md");

            var response = await Http.GetStringAsync("https://saccblazorstorage.blob.core.windows.net/markdown/blazor-resources/blazor-resources.md");

            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

            var result = Markdown.ToHtml(response, pipeline);

            RawHtml = result;
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
            }

            await jsRuntime.InvokeVoidAsync("highlightInterop.highlightCode");
        }
    }
}
