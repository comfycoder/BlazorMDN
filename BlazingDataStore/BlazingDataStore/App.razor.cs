using BlazingDataStore.Services;
using BlazingDataStore.State;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazingDataStore
{
    public partial class App
    {
        //[Inject]
        //public TranslateService Translate { get; set; }

        //[Inject]
        //public AppState AppState { get; set; }

        //[Inject]
        //public StarWarsPeopleService StarWarsPeopleService { get; set; }

        [Inject]
        ILogger<App> Logger { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Translate.SetDefaultLanguage("en");
            //Translate.SetCurrentLanguage("de");
            //await Translate.LoadLanguage("de");
            //Translate.Use("de");
            //var response = await StarWarsPeopleService.GetPeople();
            //AppState.PersonStore.SetPeople(response.Results);
            Logger.LogInformation("App Starting...");
        }
    }
}
