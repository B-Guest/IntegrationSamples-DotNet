using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web.Http;
using BGuest.Samples.Integration.Models;
using Newtonsoft.Json;

namespace BGuest.Samples.Integration.Controllers
{
    [RoutePrefix("webhooks")]
    public class WebHooksController : ApiController
    {

        [Route("requestchanges")]
        [HttpPost]
        public async Task<IHttpActionResult> Post(WebHookPayloadModel model)
        {
            // Call your PMS api or get the full request from the BGuest API here
            var messageString = JsonConvert.SerializeObject(model, Formatting.Indented);
            Debug.WriteLine(messageString);
            return Ok();
        }
    }
}
