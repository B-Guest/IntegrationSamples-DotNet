using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;
using BGuest.Samples.Integration.Webhook.Models;
using Newtonsoft.Json;

namespace BGuest.Samples.Integration.Webhook.Controllers
{
    [RoutePrefix("webhooks")]
    public class WebHooksController : ApiController
    {

        [Route("changes")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(WebHookPayloadModel model, string secret = null)
        {
            // TODO: Validate secret value
            Debug.WriteLine($"Secret code received: {secret}");
            // TODO: Call your PMS api or get the full request from the BGuest API here
            var messageString = JsonConvert.SerializeObject(model, Formatting.Indented);
            Debug.WriteLine(messageString);
            return Ok();
        }
    }
}
