using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using WebEzi.Util.Notification.Domain;
using WebEzi.Util.Notification.Domain.Model;

namespace WebEzi.Util.Notification
{
    public class NotificationFactory
    {
        #region Contruction

        private NotificationFactory()
        {
        }

        private static readonly object padlock = new object();
        private static NotificationFactory _notificationFactory;

        private NotificationModelFactory _notificationModelFactory;

        public static NotificationFactory GetInstance()
        {
            lock (padlock)
            {
                if (_notificationFactory == null)
                {
                    _notificationFactory = new NotificationFactory();
                }

                return _notificationFactory;
            }
        }

        #endregion

        #region Method

        /// <summary>
        /// Get model factory for creating model
        /// </summary>
        public NotificationModelFactory GetModelFactory()
        {
            lock (padlock)
            {
                if (_notificationModelFactory == null)
                {
                    _notificationModelFactory = new NotificationModelFactory();
                }

                return _notificationModelFactory;
            }
        }

        /// <summary>
        /// Insert notification into queue
        /// </summary>
        public void InsertNotification(INotificationRepository repository, NotificationModel model, string attachmentPath)
        {
            this.InsertNotification(repository, null, model, attachmentPath);
        }

        public void InsertNotification(INotificationRepository repository, IDbTransaction transaction,
                                       NotificationModel model, string attachmentPath)
        {
            var hasMovedFiles = new List<String>();

            try
            {
                // If it's email notification, move file
                if (model is EmailNotificationModel)
                {
                    var attachmentList = (model as EmailNotificationModel).Attachments;
                    foreach (var attach in attachmentList)
                    {
                        if (string.IsNullOrEmpty(attachmentPath))
                        {
                            throw  new Exception("The attachment path is null.");
                        }

                        var targetPath = AppDomain.CurrentDomain.BaseDirectory + attachmentPath + "\\" +
                                         attach.File.CustomPath;

                        File.Move(attach.File.PhysicalPath, targetPath
                               );
                        attach.File.SpecifiedServerPath = attachmentPath;
                        hasMovedFiles.Add(targetPath);
                    }
                }

                // Insert into database
                repository.Insert(model);
            }
            catch (Exception)
            {
                // If throw exception, we need to delete have moved files
                if (hasMovedFiles.Count > 0)
                {
                    foreach (var filePath in hasMovedFiles)
                    {
                        File.Delete(filePath);
                    }
                }

                throw;
            }
          
        }

        #endregion
    }
}
