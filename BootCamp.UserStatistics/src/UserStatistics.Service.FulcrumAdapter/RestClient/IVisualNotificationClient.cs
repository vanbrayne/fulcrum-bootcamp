using System.Threading.Tasks;
#pragma warning disable 1591

namespace UserStatistics.Service.FulcrumAdapter.RestClient
{
    public interface IVisualNotificationClient
    {
        Task VisualNotificationSuccessAsync(double? seconds = null);
        Task VisualNotificationWarningAsync(double? seconds = null);
        Task VisualNotificationErrorAsync(double? seconds = null);
    }
}