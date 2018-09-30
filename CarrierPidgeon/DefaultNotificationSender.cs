using CarrierPidgeon.Core.Notifications;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace CarrierPidgeon
{
    public class DefaultNotifiationSender : INotificationSender
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Notification> _notificationCollection;

        public DefaultNotifiationSender(IMongoClient client)
        {
            _client = client;
            _database = _client.GetDatabase("CarrierPidgeon");
            _notificationCollection = _database.GetCollection<Notification>("notifications");
        }

        public void Send(Notification notification)
        {
            _notificationCollection.InsertOne(notification);
        }

        public async Task SendAsync(Notification notification)
        {
            await _notificationCollection.InsertOneAsync(notification);
        }
    }
}