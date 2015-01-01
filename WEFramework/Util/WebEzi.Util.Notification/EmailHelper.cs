using System.Net.Mail;

namespace WebEzi.Util.Notification
{
    public class EmailHelper
    {
        private static EmailHelper _emailHelper;

        public string EmailServer { get; set; }
        public string EmailAuthName { get; set; }
        public string EmailAuthPassword { get; set; }

        public static EmailHelper GetInstance(string emailServer, string emailAuthName, string emailAuthPassword)
        {
            if(_emailHelper == null)
            {
                _emailHelper = new EmailHelper();
                _emailHelper.EmailServer = emailServer;
                _emailHelper.EmailAuthName = emailAuthName;
                _emailHelper.EmailAuthPassword = emailAuthPassword;
            }

            return _emailHelper;
        }

        public void SendEmail(MailMessage mail)
        {
            var client = new SmtpClient(this.EmailServer);
            client.Timeout = 600000;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(this.EmailAuthName, this.EmailAuthPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;

            client.Send(mail);
        }

        public void SendEmail(string from, string to, string subject, string content)
        {
            var mail = new MailMessage(from, to, subject, content);

            this.SendEmail(mail);
        }
    }
}
