using AMS.Common.Model;

namespace AMS.Notification.Model
{
    public class Notification : BaseModel
    {
        public int NotificationTypeID { get; set; }

        public string NotificationType { get; set; }
    }
}