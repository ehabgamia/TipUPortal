﻿using System.Threading.Tasks;
using MCV.Portal.Notifications;
using MCV.Portal.Test.Base;
using Shouldly;
using Xunit;

namespace MCV.Portal.Tests.Notifications
{
    // ReSharper disable once InconsistentNaming
    public class NotificationAppService_Tests : AppTestBase
    {
        private readonly INotificationAppService _notificationAppService;

        public NotificationAppService_Tests()
        {
            _notificationAppService = Resolve<INotificationAppService>();
        }

        [Fact]
        public async Task Test_ChangeNotificationSettings()
        {
            var settings = await _notificationAppService.GetNotificationSettings();
            settings.ReceiveNotifications.ShouldBe(true);
            settings.Notifications.Count.ShouldBeGreaterThan(0);
        }
    }
}
