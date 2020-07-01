using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace ComfyPWA.Client.Pages
{
    public partial class AuthorizedRoles
    {
        [CascadingParameter] 
        Task<AuthenticationState> AuthenticationStateTask { get; set; }

        public string userRoles = null;
        public string authStatus = null;

        protected override async Task OnInitializedAsync()
        {
            await UpdateAuthInfoAsync();
        }

        private async Task UpdateAuthInfoAsync()
        {
            var user = (await AuthenticationStateTask).User;

            authStatus = user.Identity.IsAuthenticated ? "Authenticated" : "NOT Authenticated";

            userRoles = "";

            if (user.IsInRole("Admin"))
            {
                userRoles += "Admin";
            }

            if (user.IsInRole("User"))
            {
                userRoles += " User";
            }
        }
    }
}
