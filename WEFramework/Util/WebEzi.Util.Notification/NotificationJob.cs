using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using WebEzi.Util.Notification.Domain;
using WebEzi.Util.ScheduleJob;
using log4net;
using WebEzi.Util.Notification.Domain.Model;

namespace WebEzi.Util.Notification
{
    public abstract class NotificationJob : BaseScheduleJob
    {
        public abstract ILog Log { get; }

        public abstract INotificationRepository Repository { get; }

        public abstract string EmailServer { get; }

        public abstract string EmailAuthName { get; }

        public abstract string EmailAuthPassword { get; }

        public abstract bool AllowSendEmail { get; }

        public abstract string DebugEmail { get; }

        public abstract string EmailFromDisplayName { get; }

        public override void Execute(Quartz.JobExecutionContext context)
        {
            this.Log.Info("Notification Job Start And Pause.");

            context.Scheduler.PauseJob(context.JobDetail.Name, context.JobDetail.Group);

            #region Execute

            // Get all awaiting notifications
            var awaitingNotificationList = this.Repository.FindNeedSendNotifications();

            // Send notification
            foreach (var awaitingNotification in awaitingNotificationList)
            {
                if (awaitingNotification is EmailNotificationModel)
                {
                    this.SendEmail(awaitingNotification as EmailNotificationModel);
                }
            }

            #endregion

            context.Scheduler.ResumeJob(context.JobDetail.Name, context.JobDetail.Group);

            this.Log.Info("Notification Job End And Resume.");
        }

        private void SendEmail(EmailNotificationModel notificationModel)
        {
            var emailHelper = EmailHelper.GetInstance(this.EmailServer, this.EmailAuthName,
                                                      this.EmailAuthPassword);

            try
            {
                var mail = this.GenerateMailMessage(notificationModel);
                if(mail == null)
                {
                    return;
                }
                else
                {
                    emailHelper.SendEmail(mail);
                }

                notificationModel.SentSuccessful();
                this.Log.Info("Sent email by key " + notificationModel.Key + " successful.");
            }
            catch (Exception e)
            {
                var errorMessage = "Sent email by key " + notificationModel.Key + " error. Message:" + e.Message +
                                   "<br>Strack:" + e.StackTrace + "Source:" +
                                   e.Source;
                this.Log.Error(errorMessage);
                notificationModel.SentFailed(errorMessage);
            }

            // Update notification
            this.Repository.Update(notificationModel);
        }

        public MailMessage GenerateMailMessage(EmailNotificationModel model)
        {
            if (AllowSendEmail)
            {
                string to;
#if DEBUG
                to = DebugEmail;
#else
                to = model.To;
#endif
                var toList = to.Split(',');
                var mail = new MailMessage { From = new MailAddress(model.From, EmailFromDisplayName) };
                for (int i = 0; i < toList.Length; i++)
                {
                    mail.To.Add(toList[i]);
                }
                
                // Add attachment
                if (model.Attachments.Count > 0)
                {
                    foreach (var attach in model.Attachments)
                    {
                        var attachment = new Attachment(new FileStream(attach.File.PhysicalPath, FileMode.Open),
                                                        attach.ExpectName);
                        mail.Attachments.Add(attachment);
                    }
                }

                mail.Subject = model.Subject;
                mail.Body = model.Content;
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;

                return mail;
            }
            else
            {
                return null;
            }
        }
    }
}
