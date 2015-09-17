using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace BGuest.Samples.Integration.Hubs
{
    public class RefreshUiHub : Hub
    {
        public static void WebhookCalled(string payload)
        {
            var dateString = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
            var message = $"[{dateString}]: {payload}";
            var hub = GlobalHost.ConnectionManager.GetHubContext<RefreshUiHub>();
            hub.Clients.All.webhookCalled(message);
        }
    }
}