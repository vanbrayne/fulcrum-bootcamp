using Xlent.Lever.Libraries2.Core.Assert;

namespace Api.Service.Models
{
    public class User : IValidatable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public void Validate(string errorLocation, string propertyPath = "")
        {
            FulcrumValidate.IsNotNullOrWhiteSpace(Name, nameof(Name), errorLocation);
            FulcrumValidate.IsNotNullOrWhiteSpace(Type, nameof(Type), errorLocation);
        }
    }
}