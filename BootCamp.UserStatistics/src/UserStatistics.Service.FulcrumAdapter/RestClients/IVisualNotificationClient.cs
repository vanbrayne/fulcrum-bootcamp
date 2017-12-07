using System.Threading.Tasks;

#pragma warning disable 1591

namespace UserStatistics.Service.FulcrumAdapter.RestClients
{
    public interface IVisualNotificationClient
    {
        Task VisualNotificationSuccessAsync();
        Task VisualNotificationWarningAsync();
        Task VisualNotificationErrorAsync();
    }
}