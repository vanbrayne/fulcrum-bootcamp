using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Service.Dal;
using Api.Service.Models;
using Xlent.Lever.KeyTranslator.RestClients.Facade.Clients;
using Xlent.Lever.KeyTranslator.Sdk;
using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Error.Logic;

namespace Api.Service.Controllers
{
    [RoutePrefix("api/Users")]
    // TODO: enable [FulcrumAuthorize(AuthenticationRoleEnum.ExternalSystemUser)]
    public class UserController : ApiController
    {
        private readonly ICustomerMasterClient _customerMasterClient;
        private readonly ITranslateClient _translateClient;

        public UserController(ICustomerMasterClient customerMasterClient, ITranslateClient translateClient)
        {
            _customerMasterClient = customerMasterClient;
            _translateClient = translateClient;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<User> Get(string id)
        {
            ServiceContract.RequireNotNullOrWhitespace(id, nameof(id));

            return await _customerMasterClient.GetUser(id);
        }

        /*
         * This method is already implemented for your convenience
         */
        [Route("")]
        [HttpGet]
        public async Task<List<User>> GetAllAsync(string type = null)
        {
            if (!string.IsNullOrWhiteSpace(type))
            {
                await new BatchTranslate(_translateClient, "mobile-app", "customer-master")
                    .Add("user.type", type, translatedValue => type = translatedValue)
                    .ExecuteAsync();
            }

            var result = await _customerMasterClient.GetUsers(type);

            var translateUp = new BatchTranslate(_translateClient, "customer-master", "mobile-app");
            foreach (var user in result)
            {
                translateUp.Add("user.type", user.Type, translatedValue => user.Type = translatedValue);
            }
            await translateUp.ExecuteAsync();

            return result;
        }

        [Route("")]
        [HttpPost]
        public async Task<string> Post(User user)
        {
            ServiceContract.RequireNotNull(user, nameof(user));
            ServiceContract.RequireValidated(user, nameof(user));

            await new BatchTranslate(_translateClient, "mobile-app", "customer-master")
                .Add("user.type", user.Type, translatedValue => user.Type = translatedValue)
                .ExecuteAsync();

            return await _customerMasterClient.AddUser(user);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<User> PutAsync(string id, User user)
        {
            ServiceContract.RequireNotNullOrWhitespace(id, nameof(id));
            ServiceContract.RequireNotNull(user, nameof(user));
            ServiceContract.RequireValidated(user, nameof(user));

            await new BatchTranslate(_translateClient, "mobile-app", "customer-master")
                .Add("user.type", user.Type, translatedValue => user.Type = translatedValue)
                .ExecuteAsync();

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
