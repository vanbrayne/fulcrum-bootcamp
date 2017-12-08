using System.Web.Http;
using Xlent.Lever.Libraries2.Core.Health.Model;

namespace PhilipsHue.Service.FulcrumAdapter.Controllers
{
    /// <summary>
    /// Meta services
    /// </summary>
    [RoutePrefix("api/ServiceMetas")]
    [AllowAnonymous]
    public class ServiceMetasController : ApiController
    {

        /// <summary>
        /// Check the health of the service
        /// </summary>
        /// <returns></returns>
        [Route("ServiceHealth")]
        [HttpGet]
        public HealthResponse ServiceHealth()
        {
            return new HealthResponse
            {
                Resource = "Philips Hue Service",
                Message = "ok",
                Status = HealthResponse.StatusEnum.Ok
            };
        }
    }
}
