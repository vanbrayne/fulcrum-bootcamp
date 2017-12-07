using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using CustomerMaster.Service.FulcrumAdapter.Contract;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Storage.Logic;
using Xlent.Lever.Libraries2.Core.Storage.Model;

namespace CustomerMaster.Service.FulcrumAdapter.Controllers
{
    /// <inheritdoc />
    // TODO: Add authentication
    // [FulcrumAuthorize(AuthenticationRoleEnum.InternalSystemUser)]
    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {
        private readonly ICrud<User, string> _persistance;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="persistance">How we deal with persistance</param>
        public UserController(ICrud<User, string> persistance)
        {
            _persistance = persistance;
        }

        [HttpPost]
        [Route("")]
        public async Task<string> Create([FromBody] User user)
        {
            ServiceContract.RequireNotNull(user, nameof(user));
            ServiceContract.RequireValidated(user, nameof(user));

            return await _persistance.CreateAsync(user);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<User> Read(string id)
        {
            ServiceContract.RequireNotNullOrWhitespace(id, nameof(id));

            return await _persistance.ReadAsync(id);
        }

        [HttpGet]
        [Route("")]
        public Task<IEnumerable<User>> ReadAll(string type = null)
        {
            var users = (IEnumerable<User>)new PageEnvelopeEnumerable<User>(offset => _persistance.ReadAllAsync(offset).Result);
            if (!string.IsNullOrWhiteSpace(type))
            {
                users = users.Where(x => x.Type == type);
            }
            return Task.FromResult(users);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task Update(string id, User user)
        {
            ServiceContract.RequireNotNullOrWhitespace(id, nameof(id));
            ServiceContract.RequireValidated(user, nameof(user));

            await _persistance.UpdateAsync(user.Id, user);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Delete(string id)
        {
            ServiceContract.RequireNotNullOrWhitespace(id, nameof(id));

            await _persistance.DeleteAsync(id);
        }

        [HttpDelete]
        [Route("")]
        public async Task DeleteAll()
        {
            await _persistance.DeleteAllAsync();
        }
    }
}
