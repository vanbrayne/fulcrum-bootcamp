using Xlent.Lever.Libraries2.Core.Assert;

namespace UserCapability.Service.FulcrumAdapter.Contract
{
    /// <summary>
    /// A user
    /// </summary>
    public class User : IValidatable
    {
        /// <summary>
        /// The unique identifier for this user
        /// </summary>
        public string Id;
        /// <summary>
        /// The name of the user
        /// </summary>
        public string Name;

        /// <inheritdoc />
        public void Validate(string errorLocation, string propertyPath = "")
        {
            FulcrumValidate.IsNotNullOrWhiteSpace(Name, nameof(Name), errorLocation);
        }
    }
}