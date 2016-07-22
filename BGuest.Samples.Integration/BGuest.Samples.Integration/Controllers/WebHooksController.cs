using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;
using BGuest.Samples.Integration.Hubs;
using BGuest.Samples.Integration.Models;
using Newtonsoft.Json;

namespace BGuest.Samples.Integration.Controllers
{
    [RoutePrefix("webhooks")]
    public class WebHooksController : ApiController
    {
        [Route("changes")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(WebHookPayloadModel model, string secret = null)
        {
            // // Validate secret value
            var apiSecret = $"ApiSecret: {secret}, ";
            // Call your PMS api or get the full request from the BGuest API here
            var messageString = apiSecret + JsonConvert.SerializeObject(model, Formatting.Indented);
            RefreshUiHub.WebhookCalled(messageString);
            Debug.WriteLine(messageString);
            return Ok();
        }
    }
}
