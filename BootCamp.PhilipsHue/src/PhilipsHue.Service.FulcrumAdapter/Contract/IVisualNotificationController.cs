using System.Threading.Tasks;

namespace PhilipsHue.Service.FulcrumAdapter.Contract
{
    /// <summary>
    /// Methods for visual notification
    /// </summary>
    public interface IVisualNotificationController
    {
        /// <summary>
        /// Visually notify that we have had a success
        /// </summary>
        Task SuccessAsync();

        /// <summary>
        /// Visually notify a warning
        /// </summary>
        Task WarningAsync();

        /// <summary>
        /// Visually notify an error
        /// </summary>
        Task ErrorAsync();
    }
}
