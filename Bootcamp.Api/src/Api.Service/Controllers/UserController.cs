using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Service.Models;
using Xlent.Lever.Authentication.Sdk.Attributes;
using Xlent.Lever.Libraries2.Core.Error.Logic;
using Xlent.Lever.Libraries2.Core.Platform.Authentication;

namespace Api.Service.Controllers
{
    [RoutePrefix("api/Users")]
    [FulcrumAuthorize(AuthenticationRoleEnum.ExternalSystemUser)]
    public class UserController : ApiController
    {
        /*
         * Implementation of GET is a mandatory exercise
         */
        [Route("{id}")]
        [HttpGet]
        public User Get(string id)
        {
            throw new FulcrumNotImplementedException();
        }

        /*
         * Implementation of POST is a mandatory exercise
         */
        [Route("")]
        [HttpPost]
        public string Post(User user)
        {
            throw new FulcrumNotImplementedException();
        }

        /*
         * Implementation of PUT is a voluntary exercise
         */
        [Route("{id}")]
        [HttpPut]
        public User Put(string id, User user)
        {
            throw new FulcrumNotImplementedException();
        }

        /*
         * Implementation of DELETE is a voluntary exercise
         */
        [Route("{id}")]
        [HttpDelete]
        public User Delete()
        {
            throw new FulcrumNotImplementedException();
        }



    }
}
