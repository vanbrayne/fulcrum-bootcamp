using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Service.Models;

namespace Api.Service.Dal
{
    public interface ICustomerMasterClient : IBaseClient
    {
        Task<string> GetUser(string id);
        Task<List<User>> GetUsers(string type = null);
        Task<string> UpdateUser(User user);
        Task<string> AddUser(User user);
        Task DeleteUser(string id);
        Task DeleteUsers();
        Task<UserStatistics> GetStatistics(string type, DateTimeOffset? startInclusive,
            DateTimeOffset? endExclusive);
    }
}