using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorStandaloneWasm.Pages
{
    public partial class Claims
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        private string authMessage;
        private string surnameMessage;
        private IEnumerable<Claim> claims = Enumerable.Empty<Claim>();

        protected async override Task OnInitializedAsync()
        {
            await GetClaimsPrincipalData();
        }

        private async Task GetClaimsPrincipalData()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                authMessage = $"{user.Identity.Name} is authenticated.";
                claims = user.Claims;
                surnameMessage = $"Surname: {user.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value}";
            }
            else
            {
                authMessage = "The user is NOT authenticated.";
            }
        }
    }
}
