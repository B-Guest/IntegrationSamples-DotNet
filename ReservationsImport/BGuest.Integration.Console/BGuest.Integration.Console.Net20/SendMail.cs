using RestSharp;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BGuest.Integration.Console.Net20
{
    public class SendGridMessage
    {
        public string Subject { get; set; }
        public string Text { get; set; }
    }

    public class SendMail
    {
        private static readonly string baseUriString = "https://api.sendgrid.com/";
        public static void ResultLogAsync(string logMessage)
        {
            var sendgridMsg = new SendGridMessage
            {
                Subject = "Reservation import log",
                Text = logMessage
            };
            SendGridMessage(sendgridMsg);
        }

        public static void SendGridMessage(SendGridMessage message)
        {
            var userName = ConfigurationManager.AppSettings["SendGrid:UserName"];
            var pwd = ConfigurationManager.AppSettings["SendGrid:Password"];
            var fromAddress = ConfigurationManager.AppSettings["SendGrid:SenderAddress"];
            var fromName = ConfigurationManager.AppSettings["SendGrid:SenderName"];
            var recipients = ConfigurationManager.AppSettings["SendGrid:Recipients"].Split(';');

            var baseUri = new Uri(baseUriString);
            var client = new RestClient(baseUri);
            client.AddDefaultHeader("Accept", "application/json");

            string destinations = string.Empty;

            //var requestApiUrl = $"api/mail.send.json?api_user={userName}&api_key={pwd}&{destinations}&subject={message.Subject}&text={message.Text}&from={fromAddress}&fromname={fromName}";
            var requestApiUrl = $"api/mail.send.json";

            var request = new RestRequest(requestApiUrl, Method.POST);
            request.AddParameter("api_user", userName);
            request.AddParameter("api_key", pwd);
            foreach (var recipient in recipients)
                request.AddParameter("to[]", recipient);
            request.AddParameter("subject", message.Subject);
            request.AddParameter("text", message.Text);
            request.AddParameter("from", fromAddress);
            request.AddParameter("fromname", fromName);

            var responseBGuest = client.Execute(request);
            if (responseBGuest.ErrorException != null)
            {
                var exception = responseBGuest.ErrorException;
                System.Console.WriteLine($"Bad response {exception}");
            }
        }

        internal static void ExceptionMessageAsync(string errorMessage, Exception exception)
        {
            var exceptionMessage = new SendGridMessage { Subject = "Import reservation exception report" };

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

