using System.Threading.Tasks;
using System.Web.Http;
using Api.Service.Dal;
using Api.Service.Models;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;

namespace Api.Service.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Authentication")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("Tokens")]
        public async Task<AccessToken> Token(AuthenticationCredentials credentials)
        {
            ServiceContract.RequireNotNull(credentials, nameof(credentials));
            ServiceContract.RequireNotNullOrWhitespace(credentials.ClientId, nameof(credentials.ClientId));
            ServiceContract.RequireNotNullOrWhitespace(credentials.ClientSecret, nameof(credentials.ClientSecret));

            return await _authenticationService.GetTokenForTenant(credentials);

        }
    }
}
