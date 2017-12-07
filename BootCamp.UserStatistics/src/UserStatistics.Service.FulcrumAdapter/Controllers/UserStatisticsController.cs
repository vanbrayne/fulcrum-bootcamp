using System;
using System.Threading.Tasks;
using System.Web.Http;
using UserStatistics.Service.FulcrumAdapter.Contract;
using Xlent.Lever.Libraries2.Core.Error.Logic;

namespace UserStatistics.Service.FulcrumAdapter.Controllers
{
    /// <inheritdoc cref="IUserStatisticsController" />
    // TODO: Add authentication
    // [FulcrumAuthorize(AuthenticationRoleEnum.InternalSystemUser)]
    [RoutePrefix("api/UserStatistics")]
    public class UserStatisticsController : ApiController, IUserStatisticsController
    {
        /// <inheritdoc />
        [HttpGet]
        [Route("")]
        public Task<Contract.UserStatistics> Read(string Type = null, DateTimeOffset? startInclusive = null, DateTimeOffset? endExclusive = null)
        {
            throw new FulcrumNotImplementedException();
        }
    }
}
