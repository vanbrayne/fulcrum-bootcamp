using System.Threading.Tasks;

namespace Api.Service.Dal
{
    public interface IVisualNotificationClient
    {
        Task VisualNotificationSuccessAsync();
        Task VisualNotificationWarningAsync();
        Task VisualNotificationErrorAsync();
    }
}