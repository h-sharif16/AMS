namespace AMS.Notification.Model
{
    public class NotificationMessages : NotificationClassification
    {
        public int NotificationMsgID { get; set; }

        public string Subject { get; set; }

        public string FromAddress { get; set; }

        public string FromAddressPssword { get; set; }

        public string MessagesBody { get; set; }
    }
}