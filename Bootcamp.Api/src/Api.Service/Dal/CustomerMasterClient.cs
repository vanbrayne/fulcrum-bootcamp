using System;
using System.Threading.Tasks;
using Api.Service.Models;
using Microsoft.Rest;
using System.Collections.Generic;
using System.Web;
using Xlent.Lever.Libraries2.Core.Error.Logic;

namespace Api.Service.Dal
{
    public class CustomerMasterClient : BaseClient, ICustomerMasterClient
    {
        public CustomerMasterClient(string baseUri, ServiceClientCredentials authenticationCredentials) : base(baseUri, authenticationCredentials)
        {
        }


        //TODO: Tutorial 1 - Implement this method
        public Task<User> GetUser(string id)
        {
            throw new FulcrumNotImplementedException();
        }

        public async Task<List<User>> GetUsers(string type = null)
        {
            var relativeUrl = "api/Users";
            if (!string.IsNullOrWhiteSpace(type)) relativeUrl += $"?type={HttpUtility.UrlEncode(type)}";
            return await RestClient.GetAsync<List<User>>(relativeUrl);
        }

        public async Task DeleteUsers()
        {
            var relativeUrl = "api/Users";
            await RestClient.DeleteAsync(relativeUrl);
        }

        //TODO: Tutorial 1 - Implement this method
        public Task DeleteUser(string id)
        {
            throw new FulcrumNotImplementedException();
        }

        public async Task<string> AddUser(User user)
        {
            var relativeUrl = "api/Users";
            return await RestClient.PostAsync<string, User>(relativeUrl, user);
        }

        //TODO: Tutorial 1 - Implement this method
        public Task<string> UpdateUser(User user)
        {
            throw new FulcrumNotImplementedException();
        }

        public async Task<UserStatistics> GetStatistics(string type = null, DateTimeOffset? startInclusive = null, DateTimeOffset? endExclusive = null)
        {
            var relativeUrl = "api/UserStatistics?";
            if (startInclusive != null)
                relativeUrl += $"&startInclusive={startInclusive}";
            if(endExclusive != null)
                relativeUrl += $"&endExclusive={endExclusive}";
            if (type != null)
                relativeUrl += $"&type={type}";

            return await RestClient.GetAsync<UserStatistics>(relativeUrl);
        }
    }
}