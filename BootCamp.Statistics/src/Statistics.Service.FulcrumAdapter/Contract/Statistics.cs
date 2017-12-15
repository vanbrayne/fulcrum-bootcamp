using System;
using Xlent.Lever.Libraries2.Core.Assert;

namespace Statistics.Service.FulcrumAdapter.Contract
{
    /// <summary>
    /// User statistics over a time interval.
    /// </summary>
    public class Statistics : IValidatable
    {
        /// <summary>
        /// The type of user (internal/external)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The start time for the statistics, inclusive the given time.
        /// </summary>
        public DateTimeOffset? StartInclusive { get; set; }

        /// <summary>
        /// The end time for the statistics, exclusive the given time.
        /// </summary>
        public DateTimeOffset? EndExlusive { get; set; }

        /// <summary>
        /// The number of created users in the time interval [<see cref="StartInclusive"/>, <see cref="EndExlusive"/>[. 
        /// </summary>
        public int Created { get; set; }

        /// <inheritdoc />
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