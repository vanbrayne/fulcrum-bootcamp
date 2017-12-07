using System.Threading.Tasks;

namespace PhilipsHue.Service.FulcrumAdapter.Contract
{
    /// <summary>
    /// Methods for visual notification
    /// </summary>
    public interface IVisualNotification
    {
        /// <summary>
        /// Visually notify that we have had a success
        /// </summary>
        Task SuccessAsync(double? seconds = null);

        /// <summary>
        /// Visually notify a warning
        /// </summary>
        Task WarningAsync(double? seconds = null);

        /// <summary>
        /// Visually notify an error
        /// </summary>
        Task ErrorAsync(double? seconds = null);
    }
}
