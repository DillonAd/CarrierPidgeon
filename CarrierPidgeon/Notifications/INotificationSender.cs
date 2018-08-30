using System;
using System.Threading.Tasks;

namespace CarrierPidgeon.Notifications
{
    public interface INotificationSender : IDisposable
    {
        void Send(Notification notification);
        Task SendAsync(Notification notification);
    }
}