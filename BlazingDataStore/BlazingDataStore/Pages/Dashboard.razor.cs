using BlazingDataStore.Models;
using BlazingDataStore.Services;
using BlazingDataStore.State;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingDataStore.Pages
{
    public partial class Dashboard
    {
        [Inject]
        public AppState Store { get; set; }

        [Inject]
        public StarWarsPeopleService StarWarsPeopleService { get; set; }

        private PeopleResponse response => Store.PersonStore.PeopleResponse;
        private Person[] people => response?.Results.ToArray();
        private bool hasPrevious => response.Previous == null ? true : false;
        private bool hasNext => response.Next == null ? true : false;

        protected override async Task OnInitializedAsync()
        {
            StarWarsPeopleService.LogVerbose = true;
            await StarWarsPeopleService.GetPeople();
        }

        private async Task Previous()
        {
            if (response?.Previous != null)
            {
                await StarWarsPeopleService.GetPeople(response.Previous);
            }
        }

        private async Task Next()
        {
            if (response?.Next != null)
            {
                await StarWarsPeopleService.GetPeople(response.Next);
            }
        }
    }
}
