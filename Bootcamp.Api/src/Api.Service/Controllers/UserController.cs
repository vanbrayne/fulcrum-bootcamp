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
    //[FulcrumAuthorize(AuthenticationRoleEnum.ExternalSystemUser)]
    public class UserController : ApiController
    {
        private readonly IUserClient _userClient;
        //private ServiceClientCre

        public UserController(IUserClient userClient)
        {
            _userClient = userClient;
        }

        [Route("{id}")]
        [HttpGet]
        public User Get(string id)
        {
            throw new FulcrumNotImplementedException();
        }

        /*
         * This method is already implemented for your convenience
         */
        [Route("")]
        [HttpGet]
        public async Task<List<User>> GetAll()
        {
            return await _userClient.GetUsers();
        }

        [Route("")]
        [HttpPost]
        public async Task<string> Post(User user)
        {
            ServiceContract.RequireNotNull(user, nameof(user));

            var relativeUrl = "api/Users";
            return await _userClient.AddUser(user);
        }

        [Route("{id}")]
        [HttpPut]
        public User Put(string id, User user)
        {
            throw new FulcrumNotImplementedException();
        }

        [Route("{id}")]
        [HttpDelete]
        public User DeleteOne(string id)
        {
            throw new FulcrumNotImplementedException();
        }

        /*
         * This method is already implemented for your convenience
         */
        [Route("")]
        [HttpDelete]
        public async Task DeleteAll()
        {
            await _userClient.DeleteUsers();
        }



    }
}
