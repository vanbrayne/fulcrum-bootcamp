using System.Threading.Tasks;
using Api.Service.Models;
using Xlent.Lever.Authentication.Sdk;
using Xlent.Lever.Libraries2.Core.MultiTenant.Model;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;

namespace Api.Service.Dal
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationManager _authenticationManager;

        public AuthenticationService(string baseUrl, ITenant tenant, AuthenticationCredentials credentials)
        {
            _authenticationManager = new AuthenticationManager(tenant, baseUrl, credentials);
        }

        public async Task<AccessToken> GetTokenForTenant(AuthenticationCredentials credentials)
        {
            IAuthenticationCredentials tokenCredentials = new AuthenticationCredentials
            {
                ClientId = credentials.ClientId,
                ClientSecret = credentials.ClientSecret
            };
            AuthenticationToken token = (AuthenticationToken)await _authenticationManager.GetJwtTokenAsync(tokenCredentials);

            var result = new AccessToken
            {
                Token = token.AccessToken,
                ExpiresOnUtc = token.ExpiresOn
            };


            return result;
        }
    }
}