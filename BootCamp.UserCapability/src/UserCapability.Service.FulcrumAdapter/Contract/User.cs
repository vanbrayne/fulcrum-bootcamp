using Xlent.Lever.Libraries2.Core.Assert;
using Xlent.Lever.Libraries2.Core.Misc.Models;
using Xlent.Lever.Libraries2.Core.Storage.Model;

namespace UserCapability.Service.FulcrumAdapter.Contract
{
    /// <summary>
    /// A user
    /// </summary>
    public class User : IValidatable, IUniquelyIdentifiable<string>, IOptimisticConcurrencyControlByETag
    {
        /// <inheritdoc />
        public string Id { get; set; }

        /// <summary>
        /// The name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of user (internal/external)
        /// </summary>
        public string Type { get; set; }

        /// <inheritdoc />
        public string Etag { get; set; }

        /// <inheritdoc />
        public void Validate(string errorLocation, string propertyPath = "")
        {
            FulcrumValidate.IsNotNullOrWhiteSpace(Name, nameof(Name), errorLocation);
            // TODO: More validation?
        }
    }
}