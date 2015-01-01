using System;
using WebEzi.Base.DefinedData;
using WebEzi.Core.Domain.Base;
using WebEzi.Core.Domain.Base.Model;
using WebEzi.Core.Domain.Base.ModelFactory;
using WebEzi.Util.Notification.Domain.Model;

namespace WebEzi.Util.Notification.Domain
{
    /// <summary>
    /// Notification Factory
    /// </summary>
    public class NotificationModelFactory : ModelFactoryBase
    {
        internal NotificationModelFactory()
        {
        }

        #region Email Notfication

        /// <summary>
        /// Create email notification for create
        /// </summary>
        public EmailNotificationModel CreateEmailNotification(
            string from,
            string to,
            string subject,
            string content,
            WEList<WEAttachment> attachments,
            WEDateTime readySendTime)
        {
            return CreateEmailNotification(WEKey.NullValue,
                                           from,
                                           to,
                                           subject,
                                           content,
                                           attachments,
                                           readySendTime,
                                           string.Empty,
                                           string.Empty,
                                           DateTime.Now,
                                           NotificationStatusConst.Awaiting);
        }

        /// <summary>
        /// Create email notification for edit
        /// </summary>
        public EmailNotificationModel CreateEmailNotification(
            WEKey key,
            string from,
            string to,
            string subject,
            string content,
            WEList<WEAttachment> attachments,
            WEDateTime readySendTime,
            WEDateTime actualSendTime,
            string failedMessage,
            WEDateTime dateCreated,
            NotificationStatusConst status)
        {
            var model = new EmailNotificationModel(key)
                            {
                                From = from,
                                To = to,
                                Content = content,
                                Subject = subject,
                                Attachments = attachments,
                                ReadySendTime = readySendTime,
                                ActualSendTime = actualSendTime,
                                FailedMessage = failedMessage,
                                DateCreated = dateCreated,
                                Status = status
                            };


            return model;
        }

        #endregion

        #region SMS

        /// <summary>
        /// Create sms notification for create
        /// </summary>
        public SMSNotificationModel CreateSMSNotification(string to,
                                                          string content,
                                                          string subject,
                                                          WEDateTime readySendTime)
        {
            return CreateSMSNotification(WEKey.NullValue,
                                         to,
                                         subject,
                                         content,
                                         readySendTime,
                                         string.Empty,
                                         string.Empty,
                                         DateTime.Now,
                                         NotificationStatusConst.Awaiting);

        }

        /// <summary>
        /// Create sms notification for edit
        /// </summary>
        public SMSNotificationModel CreateSMSNotification(WEKey key,
                                                            string to,
                                                            string subject,
                                                            string content,
                                                            WEDateTime readySendTime,
                                                            WEDateTime actualSendTime,
                                                            string failedMessage,
                                                            WEDateTime dateCreated,
                                                            NotificationStatusConst status)
        {
            var model = new SMSNotificationModel(key)
                            {
                                To = to,
                                Subject = subject,
                                Content = content,
                                ReadySendTime = readySendTime,
                                ActualSendTime = actualSendTime,
                                FailedMessage = failedMessage,
                                DateCreated = dateCreated,
                                Status = status
                            };

            return model;
        }

        #endregion

        #region Mobile Notification

        /// <summary>
        /// Create mobile device notification for create
        /// </summary>
        public MobileDeviceNotificationModel CreateMobileDeviceNotification(string to,
                                                                            string subject,
                                                                            string content,
                                                                            WEDateTime readySendTime)
        {
            return CreateMobileDeviceNotification(WEKey.NullValue,
                                                  to,
                                                  subject,
                                                  content,
                                                  readySendTime,
                                                  string.Empty,
                                                  string.Empty,
                                                  DateTime.Now,
                                                  NotificationStatusConst.Awaiting);
        }

        /// <summary>
        /// Create mobile device notification for edit
        /// </summary>
        public MobileDeviceNotificationModel CreateMobileDeviceNotification(WEKey key,
                                                                              string to,
                                                                              string subject,
                                                                              string content,
                                                                              WEDateTime readySendTime,
                                                                              WEDateTime actualSendTime,
                                                                              string failedMessage,
                                                                              WEDateTime dateCreated,
                                                                              NotificationStatusConst status)
        {
            var model = new MobileDeviceNotificationModel(key)
                            {
                                To = to,
                                Subject = subject,
                                Content = content,
                                ReadySendTime = readySendTime,
                                ActualSendTime = actualSendTime,
                                FailedMessage = failedMessage,
                                DateCreated = dateCreated,
                                Status = status
                            };


            return model;
        }

        #endregion
    }
}
