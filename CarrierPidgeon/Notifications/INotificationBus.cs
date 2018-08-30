using System;

namespace CarrierPidgeon.Notifications
{
    public interface INotificationBus : IDisposable
    {
        void Push(Notification notification);
    }
}