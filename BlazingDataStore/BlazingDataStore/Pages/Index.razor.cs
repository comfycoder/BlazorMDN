using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingDataStore.Pages
{
    public partial class Index
    {
        [Inject]
        ILogger<Index> Logger { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Logger.LogInformation("Index...");
        }
    }
}
