using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace LeaveManagementPortal.Authentication
{
    public class CustomAuthenticationStateProvider
     : AuthenticationStateProvider
    {
        private ClaimsPrincipal _currentUser =
            new ClaimsPrincipal(
                new ClaimsIdentity());

        public override Task<AuthenticationState>
            GetAuthenticationStateAsync()
        {
            return Task.FromResult(
                new AuthenticationState(_currentUser));
        }

        public void Login(string username, string role)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),

            new Claim(ClaimTypes.Role, role)
        };

            var identity = new ClaimsIdentity(
                claims,
                "CustomAuthentication");

            _currentUser =
                new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(
                GetAuthenticationStateAsync());
        }

        public void Logout()
        {
            _currentUser =
                new ClaimsPrincipal(
                    new ClaimsIdentity());

            NotifyAuthenticationStateChanged(
                GetAuthenticationStateAsync());
        }
    }
}
