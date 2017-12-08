using System;
using Xlent.Lever.Libraries2.Core.Assert;

namespace Api.Service.Models
{
    public class UserStatistics : IValidatable
    {
        public string Type { get; set; }

        public DateTimeOffset? StartInclusive { get; set; }

        public DateTimeOffset? EndExlusive { get; set; }

        public int Created { get; set; }

        public void Validate(string errorLocation, string propertyPath = "")
        {
            if (Type != null)
            {
                FulcrumValidate.IsTrue(Type == "private" || Type == "public", null, $"{nameof(Type)} must have one of the values \"private\" and \"public\".");
            }
            FulcrumValidate.IsGreaterThanOrEqualTo(0, Created, nameof(Created), errorLocation);
            var now = DateTimeOffset.Now;
            if (StartInclusive != null) FulcrumValidate.IsLessThanOrEqualTo(now, StartInclusive.Value, nameof(StartInclusive), errorLocation);
            if (EndExlusive != null) FulcrumValidate.IsLessThanOrEqualTo(now, EndExlusive.Value, nameof(EndExlusive), errorLocation);
            // TODO: More validation?
        }
    }
}