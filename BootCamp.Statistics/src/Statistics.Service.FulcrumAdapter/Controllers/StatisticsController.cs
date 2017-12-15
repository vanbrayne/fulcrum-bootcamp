using System;
using System.Threading.Tasks;
using System.Web.Http;
using Xlent.Lever.Authentication.Sdk.Attributes;
using Xlent.Lever.Libraries2.Core.Error.Logic;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;

namespace Statistics.Service.FulcrumAdapter.Controllers
{
    /// <summary>
    /// StatisticsController
    /// </summary>
    [FulcrumAuthorize(AuthenticationRoleEnum.InternalSystemUser)]
    [RoutePrefix("api/Statistics")]
    public class StatisticsController : ApiController
    {

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="type"></param>
        /// <param name="startInclusive"></param>
        /// <param name="endExclusive"></param>
        /// <returns></returns>
        /// <exception cref="FulcrumNotImplementedException"></exception>
        [HttpGet]
        [Route("")]
        public Task<Contract.Statistics> Read(string type = null, DateTimeOffset? startInclusive = null, DateTimeOffset? endExclusive = null)
        {
            // Tips: "type" can be "private" or "public", see http://lever.xlent-fulcrum.info/wiki/Bootcamp_course#user.type
            throw new FulcrumNotImplementedException();
        }
    }
}
