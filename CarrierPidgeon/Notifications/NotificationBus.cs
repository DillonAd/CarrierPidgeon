using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarrierPidgeon.Notifications
{
    public class NotificationBus : INotificationBus
    {
        private readonly INotificationSender _sender;

        private event EventHandler<SendNotificationEventArgs> _enqueued;

        public NotificationBus(INotificationSender sender)
        {
            _sender = sender;

            _enqueued += Send;
        }

        public void Push(Notification notification)
        {
            _enqueued(this, new SendNotificationEventArgs(notification));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if(disposing)
            {
                _sender.Dispose();
            }
        }

        private void Send(object sender, SendNotificationEventArgs e)
        {
            _sender.SendAsync(e.Notification);
        }

        class SendNotificationEventArgs
        {
            internal Notification Notification { get; }

            public SendNotificationEventArgs(Notification notification)
            {
                Notification = notification;
            }
        }
    }
}