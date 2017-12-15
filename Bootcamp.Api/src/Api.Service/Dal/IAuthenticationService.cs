using System.Threading.Tasks;
using Api.Service.Models;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;

namespace Api.Service.Dal
{
    public interface IAuthenticationService
    {
        Task<AccessToken> GetTokenForTenant(AuthenticationCredentials credentials);
    }
}