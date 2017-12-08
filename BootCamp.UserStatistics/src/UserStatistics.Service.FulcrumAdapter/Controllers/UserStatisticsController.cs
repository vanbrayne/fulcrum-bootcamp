using System;
using System.Threading.Tasks;
using System.Web.Http;
using UserStatistics.Service.FulcrumAdapter.Contract;
using Xlent.Lever.Authentication.Sdk.Attributes;
using Xlent.Lever.Libraries2.Core.Error.Logic;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;

namespace UserStatistics.Service.FulcrumAdapter.Controllers
{
    /// <inheritdoc cref="IUserStatisticsController" />
    [FulcrumAuthorize(AuthenticationRoleEnum.InternalSystemUser)]
    [RoutePrefix("api/UserStatistics")]
    public class UserStatisticsController : ApiController, IUserStatisticsController
    {
        /// <inheritdoc />
        [HttpGet]
        [Route("")]
        public Task<Contract.UserStatistics> Read(string type = null, DateTimeOffset? startInclusive = null, DateTimeOffset? endExclusive = null)
        {
            // Tips: "type" can be "private" or "public", see http://lever.xlent-fulcrum.info/wiki/Bootcamp_course#user.type
            throw new FulcrumNotImplementedException();
        }
    }
}
