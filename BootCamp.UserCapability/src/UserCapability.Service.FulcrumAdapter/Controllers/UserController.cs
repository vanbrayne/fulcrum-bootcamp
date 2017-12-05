using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using UserCapability.Service.FulcrumAdapter.Contract;
using Xlent.Lever.Authentication.Sdk.Attributes;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Error.Logic;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;
using Xlent.Lever.Libraries2.Core.Storage.Model;

namespace UserCapability.Service.FulcrumAdapter.Controllers
{
    [FulcrumAuthorize(AuthenticationRoleEnum.InternalSystemUser)]
    [RoutePrefix("api")]
    public class UserController : ApiController, IUserController
    {
        private readonly User _mockUser = new User
        {
            Id = "1",
            Name = "John Doe"
        };
        /// <inheritdoc />
        [HttpPost]
        [Route("Users")]
        public async Task<string> Create([FromBody]User user)
        {
            ServiceContract.RequireNotNull(user, nameof(user));
            ServiceContract.RequireValidated(user, nameof(user));

            return await Task.FromResult("1");
        }

        /// <inheritdoc />
        [HttpGet]
        [Route("Users/{id}")]
        public Task<User> Read(string id)
        {
            ServiceContract.RequireNotNullOrWhitespace(id, nameof(id));
            ServiceContract.Require(id == "1", $"{nameof(id)} must be equal to 1");

            return Task.FromResult(_mockUser);
        }

        /// <inheritdoc />
        [HttpGet]
        [Route("Users")]
        public Task<PageEnvelope<User>> ReadAll(int offset = 0, int? limit = null)
        {
            ServiceContract.RequireGreaterThanOrEqualTo(0, offset, nameof(offset));
            if (limit != null) ServiceContract.RequireGreaterThanOrEqualTo(1, limit.Value, nameof(limit));

            var page = new PageEnvelope<User>()
            {
                PageInfo = new PageInfo
                {
                    Offset = offset,
                    Limit = limit ?? 100,
                    Returned = 1,
                    Total = 1
                },
                Data = new List<User> {_mockUser}
            };

            return Task.FromResult(page);
        }

        /// <inheritdoc />
        [HttpPut]
        [Route("Users/{id}")]
        public Task Update(string id, User user)
        {
            throw new FulcrumNotImplementedException();
        }

        /// <inheritdoc />
        [HttpDelete]
        [Route("Users/{id}")]
        public Task Delete(string id)
        {
            throw new FulcrumNotImplementedException();
        }

        /// <inheritdoc />
        [HttpDelete]
        [Route("Users")]
        public Task DeleteAll()
        {
            throw new FulcrumNotImplementedException();
        }
    }
}
