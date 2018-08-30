using CarrierPidgeon.Core.Notifications;
using Moq;
using System.Collections.Generic;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace CarrierPidgeon.Test
{
    public class NotificationBus_Tests
    {
        private readonly ITestOutputHelper _output;

        public NotificationBus_Tests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(5000)]
        [Trait("Category", "unit")]
        public void Send_Notification_Success(int notificationCount)
        {
            //Assemble
            var sentNotifications = new List<Notification>();

            var senderMock = new Mock<INotificationSender>();
            senderMock.Setup(s => s.SendAsync(It.IsAny<Notification>()))
                .Callback<Notification>(n => sentNotifications.Add(n));
            
            var sut = new NotificationBus(senderMock.Object);
            
            //Act
            for(int i = 0; i < notificationCount; i++)
            {
                sut.Push(new Notification(string.Empty, string.Empty, string.Empty));
            }

            sut.Dispose();

            //Assert
            Assert.Equal(notificationCount, sentNotifications.Count);
        }
    }
}