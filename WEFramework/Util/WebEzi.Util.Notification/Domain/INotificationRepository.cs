using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebEzi.Base.DefinedData;
using WebEzi.Core.Domain.Base.Repository;
using WebEzi.Util.Notification.Domain.Model;

namespace WebEzi.Util.Notification.Domain
{
    public interface INotificationRepository : IRepository<NotificationModel>
    {
        WEList<NotificationModel> FindNeedSendNotifications();
    }
}
