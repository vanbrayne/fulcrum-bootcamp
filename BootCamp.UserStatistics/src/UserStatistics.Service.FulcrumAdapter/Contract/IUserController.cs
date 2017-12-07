using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserStatistics.Service.FulcrumAdapter.Contract
{
    /// <summary>
    /// Methods for a <see cref="User"/> resource.
    /// </summary>
    public interface IUserController
    {
        /// <summary>
        /// Create a <paramref name="user"/>.
        /// </summary>
        /// <param name="user">The data for the user to create.</param>
        /// <returns>The id for the new user.</returns>
        Task<string> Create(User user);

        /// <summary>
        /// Read the user with id <paramref name="id"/>.
        /// </summary>
        /// <returns>The </returns>
        Task<User> Read(string id);

        /// <summary>
        /// Read all the users.
        /// </summary>
        /// <returns>The </returns>
        Task<IEnumerable<User>> ReadAll();

        /// <summary>
        /// Update the user with id <paramref name="id"/> the the values of <paramref name="user"/>.
        /// </summary>
        /// <returns>The </returns>
        Task Update(string id, User user);

        /// <summary>
        /// Delete the user with id <paramref name="id"/>.
        /// </summary>
        Task Delete(string id);

        /// <summary>
        /// Delete all the users
        /// </summary>
        Task DeleteAll();
    }
}
