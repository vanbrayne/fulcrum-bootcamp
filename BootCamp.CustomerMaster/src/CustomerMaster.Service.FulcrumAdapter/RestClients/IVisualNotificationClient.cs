using System.Threading.Tasks;

namespace CustomerMaster.Service.FulcrumAdapter.Dal
{

    /// <summary>
    /// HueClient interface
    /// </summary>
    public interface IVisualNotificationClient
    {
        /// <summary>
        /// Trigger VisualNotificationSuccess
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        Task VisualNotificationSuccessAsync(double seconds);

        /// <summary>
        /// Trigger VisualNotificationWarning
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        Task VisualNotificationWarningAsync(double seconds);

        /// <summary>
        /// Trigger VisualNotificationError
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        Task VisualNotificationErrorAsync(double seconds);
    }

}