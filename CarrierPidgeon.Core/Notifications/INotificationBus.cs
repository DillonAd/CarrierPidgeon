using System;

namespace CarrierPidgeon.Core.Notifications
{
    public interface INotificationBus
    {
        void Push(Notification notification);
    }
}