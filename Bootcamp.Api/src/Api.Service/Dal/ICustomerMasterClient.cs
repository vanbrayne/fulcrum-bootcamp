using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Service.Models;

namespace Api.Service.Dal
{
    public interface ICustomerMasterClient
    {
        Task<List<User>> GetUsers(string type = null);
        Task<string> AddUser(User user);
        Task DeleteUsers();
    }
}