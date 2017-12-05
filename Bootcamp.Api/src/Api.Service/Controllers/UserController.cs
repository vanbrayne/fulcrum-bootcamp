using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Service.Dal;
using Api.Service.Models;
using Microsoft.Rest;
using Xlent.Lever.Authentication.Sdk.Attributes;
using Xlent.Lever.Libraries2.Core.Error.Logic;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;

namespace Api.Service.Controllers
{
    [RoutePrefix("api/Users")]
    [FulcrumAuthorize(AuthenticationRoleEnum.ExternalSystemUser)]
    public class UserController : ApiController
    {
        private readonly IUserClient _userClient;

        public UserController(string baseUrl, ServiceClientCredentials credentials)
        {
            _userClient = new UserClient(baseUrl, credentials);
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
        public string Post(User user)
        {
            throw new FulcrumNotImplementedException();
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
