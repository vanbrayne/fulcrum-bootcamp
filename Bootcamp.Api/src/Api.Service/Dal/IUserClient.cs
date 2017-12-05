using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Service.Models;

namespace Api.Service.Dal
{
    public interface IUserClient
    {
        Task<List<User>> GetUsers();
        Task DeleteUsers();
    }
}