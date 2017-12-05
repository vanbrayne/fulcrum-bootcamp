using System.Threading.Tasks;
using System.Web.Http;
using UserCapability.Service.FulcrumAdapter.Contract;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Storage.Model;

namespace UserCapability.Service.FulcrumAdapter.Controllers
{
    /// <inheritdoc cref="IUserController" />
    // TODO: Add authentication
    // [FulcrumAuthorize(AuthenticationRoleEnum.InternalSystemUser)]
    [RoutePrefix("api")]
    public class UserController : ApiController, IUserController
    {
        private readonly ICrudAll<User, string> _persistance;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="persistance">How we deal with persistance</param>
        public UserController(ICrudAll<User, string> persistance)
        {
            _persistance = persistance;
        }
        /// <inheritdoc />
        [HttpPost]
        [Route("Users")]
        public async Task<User> Create([FromBody] User user)
        {
            ServiceContract.RequireNotNull(user, nameof(user));
            ServiceContract.RequireValidated(user, nameof(user));

            return await _persistance.CreateAsync(user);
        }

        /// <inheritdoc />
        [HttpGet]
        [Route("Users/{id}")]
        public async Task<User> Read(string id)
        {
            ServiceContract.RequireNotNullOrWhitespace(id, nameof(id));

            return await _persistance.ReadAsync(id);
        }

        /// <inheritdoc />
        [HttpGet]
        [Route("Users")]
        public async Task<PageEnvelope<User>> ReadAll(int offset = 0, int? limit = null)
        {
            ServiceContract.RequireGreaterThanOrEqualTo(0, offset, nameof(offset));
            if (limit != null) ServiceContract.RequireGreaterThanOrEqualTo(1, limit.Value, nameof(limit));

            return await _persistance.ReadAllAsync(offset, limit);
        }

        /// <inheritdoc />
        [HttpPut]
        [Route("Users/{id}")]
        public async Task Update(string id, User user)
        {
            ServiceContract.RequireNotNullOrWhitespace(id, nameof(id));
            ServiceContract.RequireValidated(user, nameof(user));

            await _persistance.UpdateAsync(user);
        }

        /// <inheritdoc />
        [HttpDelete]
        [Route("Users/{id}")]
        public async Task Delete(string id)
        {
            ServiceContract.RequireNotNullOrWhitespace(id, nameof(id));

            await _persistance.DeleteAsync(id);
        }

        /// <inheritdoc />
        [HttpDelete]
        [Route("Users")]
        public async Task DeleteAll()
        {
            await _persistance.DeleteAllAsync();
        }
    }
}
