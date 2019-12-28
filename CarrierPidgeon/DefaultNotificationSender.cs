using CarrierPidgeon.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarrierPidgeon
{
    public class DefaultNotifiationSender : INotificationSender
    {
        private readonly List<Notification> _notifications; 

        public DefaultNotifiationSender()
        {
            _notifications = new List<Notification>();
        }

        public void Send(Notification notification)
        {
            _notifications.Add(notification);
            RemoveOutOfDateNotifications();
        }

        public async Task SendAsync(Notification notification) =>
            await Task.Run(() => Send(notification));

        public void RemoveOutOfDateNotifications()
        {
            for(int i = 0; i < _notifications.Count; i++)
            {
                if(_notifications[i].Created < DateTime.UtcNow.AddDays(1))
                {
                    _notifications.Remove(_notifications[i]);
                }
            }
        }
    }
}