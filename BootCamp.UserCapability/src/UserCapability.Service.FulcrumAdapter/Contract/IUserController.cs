using System.Threading.Tasks;
using Xlent.Lever.Libraries2.Core.Storage.Model;

namespace UserCapability.Service.FulcrumAdapter.Contract
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
        Task<User> Create(User user);

        /// <summary>
        /// Read the user with id <paramref name="id"/>.
        /// </summary>
        /// <returns>The </returns>
        Task<User> Read(string id);

        /// <summary>
        /// Read all the users.
        /// </summary>
        /// <param name="offset">The first user to return in the page.</param>
        /// <param name="limit">The maximum number of item to return in a page.</param>
        /// <returns>The </returns>
        Task<PageEnvelope<User>> ReadAll(int offset = 0, int? limit = null);

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
