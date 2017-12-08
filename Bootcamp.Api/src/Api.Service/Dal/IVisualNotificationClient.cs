using System.Threading.Tasks;

namespace Api.Service.Dal
{
    public interface IVisualNotificationClient : IBaseClient
    {
        Task VisualNotificationSuccessAsync();
        Task VisualNotificationWarningAsync();
        Task VisualNotificationErrorAsync();
    }
}