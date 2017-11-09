using AMS.Common.Model;

namespace AMS.Notification.Model
{
    public class SmtpCredentials : BaseModel
    {
        public string MailServer { get; set; }

        public int PortNumber { get; set; }
    }
}