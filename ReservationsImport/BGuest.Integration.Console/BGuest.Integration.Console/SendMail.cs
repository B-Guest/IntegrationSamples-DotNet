using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using SendGrid;

namespace BGuest.Integration.Console
{
    public class SendMail
    {
        public static void ResultLogAsync(string logMessage)
        {
            var htmlText = "<body>" + logMessage.Replace(Environment.NewLine, "<br/>") + "</body>";
            var sendgridMsg = new SendGridMessage
            {
                Subject = "Reservation import log",
                Html = htmlText
            };
            SendGridMessage(sendgridMsg);
        }

        public static void SendGridMessage(SendGridMessage message)
        {
            var userName = ConfigurationManager.AppSettings["SendGrid:UserName"];
            var pwd = ConfigurationManager.AppSettings["SendGrid:Password"];
            var credentials = new NetworkCredential(userName, pwd);
            var transportWeb = new Web(credentials);
            message.From = new MailAddress(ConfigurationManager.AppSettings["SendGrid:SenderAddress"], 
                ConfigurationManager.AppSettings["SendGrid:SenderName"]);
            var recipients = ConfigurationManager.AppSettings["SendGrid:Recipients"].Split(';');
            message.AddTo(recipients);

            var res = transportWeb.DeliverAsync(message);
            res.Wait();
        }

        internal static void ExceptionMessageAsync(string errorMessage, Exception exception)
        {
            var exceptionMessage = new SendGridMessage {Subject = "Import reservation exception report"};

            var message = new StringBuilder();
            message.AppendFormat("Message: {0}", errorMessage);
            message.AppendLine();
            message.AppendFormat("Exception: {0}", exception.Message);
            message.AppendLine();
            message.AppendFormat("Inner Exception: {0}", exception.InnerException?.Message);
            exceptionMessage.Text = message.ToString();

            SendGridMessage(exceptionMessage);
        }
    }
}

