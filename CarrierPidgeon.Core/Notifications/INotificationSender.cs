using System.Threading.Tasks;

namespace CarrierPidgeon.Core.Notifications
{
    public interface INotificationSender
    {
        void Send(Notification notification);
        Task SendAsync(Notification notification);
    }
}