using System.Threading.Tasks;
using Api.Service.Models;
using Microsoft.Rest;
using Xlent.Lever.Libraries2.Core.Assert;
using System.Collections.Generic;

namespace Api.Service.Dal
{
    public class UserClient : BaseClient, IUserClient
    {
        public UserClient(string baseUri, ServiceClientCredentials authenticationCredentials) : base(baseUri, authenticationCredentials)
        {
        }

        public async Task<List<User>> GetUsers()
        {
            var relativeUrl = $"api/Users";
            return await RestClient.GetAsync<List<User>>(relativeUrl);
        }

        public async Task DeleteUsers()
        {
            var relativeUrl = $"api/Users";
            await RestClient.DeleteAsync(relativeUrl);
        }

        public async Task<string> AddUser(User user)
        {
            var relativeUrl = $"api/Users";
            return await RestClient.PostAsync<string, User>(relativeUrl, user);
        }
    }
}