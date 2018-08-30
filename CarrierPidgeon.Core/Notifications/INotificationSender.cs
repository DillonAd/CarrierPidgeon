using System;
using System.Threading.Tasks;

namespace CarrierPidgeon.Core.Notifications
{
    public interface INotificationSender : IDisposable
    {
        void Send(Notification notification);
        Task SendAsync(Notification notification);
    }
}