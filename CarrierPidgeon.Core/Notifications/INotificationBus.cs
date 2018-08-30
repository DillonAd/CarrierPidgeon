using System;

namespace CarrierPidgeon.Core.Notifications
{
    public interface INotificationBus : IDisposable
    {
        void Push(Notification notification);
    }
}