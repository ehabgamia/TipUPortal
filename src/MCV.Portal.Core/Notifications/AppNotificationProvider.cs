using Abp.Authorization;
using Abp.Localization;
using Abp.Notifications;
using MCV.Portal.Authorization;

namespace MCV.Portal.Notifications
{
    public class AppNotificationProvider : NotificationProvider
    {
        public override void SetNotifications(INotificationDefinitionContext context)
        {
            context.Manager.Add(
                new NotificationDefinition(
                    AppNotificationNames.NewUserRegistered,
                    displayName: L("NewUserRegisteredNotificationDefinition"),
                    permissionDependency: new SimplePermissionDependency(AppPermissions.Pages_Administration_Users)
                    )
                );

            context.Manager.Add(
                new NotificationDefinition(
                    AppNotificationNames.NewTenantRegistered,
                    displayName: L("NewTenantRegisteredNotificationDefinition"),
                    permissionDependency: new SimplePermissionDependency(AppPermissions.Pages_Tenants)
                    )
                );

            context.Manager.Add(
              new NotificationDefinition(
                  AppNotificationNames.NewSubject,
                  displayName: L("NewSubjectNotification")
                  )
              );

            context.Manager.Add(
               new NotificationDefinition(
                   AppNotificationNames.ITServiceNotification,
                   displayName: L("New Request Notification")
                   )
               );

            context.Manager.Add(
               new NotificationDefinition(
                   AppNotificationNames.ApproveNotification,
                   displayName: L("Approved Notification")
                   )
               );

            context.Manager.Add(
               new NotificationDefinition(
                   AppNotificationNames.RejectNotification,
                   displayName: L("Reject Notification")
                   )
               );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PortalConsts.LocalizationSourceName);
        }
    }
}
