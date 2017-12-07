using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Service.Models;

namespace Api.Service.Dal
{
    public interface IUserClient
    {
        Task<List<User>> GetUsers();
        Task<string> AddUser(User user);
        Task DeleteUsers();
        Task<UserStatistics> GetStatistics(string type, DateTimeOffset? startInclusive, DateTimeOffset? endExclusive);
    }
}