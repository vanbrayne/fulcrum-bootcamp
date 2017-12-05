using Xlent.Lever.Libraries2.Core.Assert;

namespace UserCapability.Service.FulcrumAdapter.Contract
{
    public class User : IValidatable
    {
        public string Id;
        public string Name;

        public void Validate(string errorLocation, string propertyPath = "")
        {
            FulcrumValidate.IsNotNullOrWhiteSpace(Name, nameof(Name), errorLocation);
        }
    }
}