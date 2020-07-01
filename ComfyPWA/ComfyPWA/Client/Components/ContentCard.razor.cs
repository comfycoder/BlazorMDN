using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComfyPWA.Client.Components
{
    public partial class ContentCard
    {

        [Parameter]
        public string ImageSrc { get; set; }

        [Parameter]
        public string ImageAlt { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Description { get; set; }

        [Parameter]
        public string TargetUrl { get; set; }
    }
}
