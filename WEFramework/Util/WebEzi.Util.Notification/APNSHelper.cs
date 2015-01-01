using System;

namespace WebEzi.Util.Notification
{
    /// <summary>
    /// Refernce the act project, complete it later
    /// </summary>
    public class APNSHelper
    {
        public static string SendNotification(bool isUsedTest, string keyFile, string password, string deviceToken, string content, string key, object[]value)
        {
            var message = string.Empty;

            //try
            //{
            //    NotificationService service = new NotificationService(isUsedTest, keyFile, password, 1);
            //    service.SendRetries = 5; //5 retries before generating notificationfailed event
            //    service.ReconnectDelay = 5000; //5 seconds

            //    //Create a new notification to send
            //    Notification alertNotification = new Notification(deviceToken);

            //    alertNotification.Payload.Alert.Body = string.Format(content, 0);
            //    if (!string.IsNullOrEmpty(key))
            //    {
            //        alertNotification.Payload.CustomItems.Add(key, value);
            //    }
            //    alertNotification.Payload.Sound = "default";
            //    alertNotification.Payload.Badge = 0;

            //    //Queue the notification to be sent
            //    service.QueueNotification(alertNotification);

            //    System.Threading.Thread.Sleep(5000);

            //    //First, close the service.  
            //    //This ensures any queued notifications get sent befor the connections are closed
            //    service.Close();

            //    //Clean up
            //    service.Dispose();
            //}
            //catch (Exception e)
            //{
            //    message = e.Message;
            //}

            return message;
        }
    }
}
