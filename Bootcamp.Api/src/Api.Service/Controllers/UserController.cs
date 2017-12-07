using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Service.Dal;
using Api.Service.Models;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Error.Logic;

namespace Api.Service.Controllers
{
    [RoutePrefix("api/Users")]
    // TODO: enable [FulcrumAuthorize(AuthenticationRoleEnum.ExternalSystemUser)]
    public class UserController : ApiController
    {
        private readonly ICustomerMasterClient _customerMasterClient;

        public UserController(ICustomerMasterClient customerMasterClient)
        {
            _customerMasterClient = customerMasterClient;
        }

        [Route("{id}")]
        [HttpGet]
        public User Get(string id)
        {
            ServiceContract.RequireNotNullOrWhitespace(id, nameof(id));

            throw new FulcrumNotImplementedException();
        }

        /*
         * This method is already implemented for your convenience
         */
        [Route("")]
        [HttpGet]
        public async Task<List<User>> GetAll(string type = null)
        {
            // TODO: translate type
            return await _customerMasterClient.GetUsers(type);
        }

        [Route("")]
        [HttpPost]
        public async Task<string> Post(User user)
        {
            ServiceContract.RequireNotNull(user, nameof(user));

            return await _customerMasterClient.AddUser(user);
        }

        [Route("{id}")]
        [HttpPut]
        public User Put(string id, User user)
        {
            ServiceContract.RequireNotNullOrWhitespace(id, nameof(id));
            ServiceContract.RequireNotNull(user, nameof(user));

            throw new FulcrumNotImplementedException();
        }

        [Route("{id}")]
        [HttpDelete]
        public User DeleteOne(string id)
        {
            ServiceContract.RequireNotNullOrWhitespace(id, nameof(id));

            throw new FulcrumNotImplementedException();
        }

        /*
         * This method is already implemented for your convenience
         */
        [Route("")]
        [HttpDelete]
        public async Task DeleteAll()
        {
            await _customerMasterClient.DeleteUsers();
        }
    }
}
