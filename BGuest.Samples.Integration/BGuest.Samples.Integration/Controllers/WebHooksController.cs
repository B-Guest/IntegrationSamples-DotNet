using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using Newtonsoft.Json;

namespace BGuest.Samples.Integration.Controllers
{
    [RoutePrefix("webhooks")]
    public class WebHooksController : ApiController
    {

        [Route("requestchanges")]
        [HttpPost]
        public HttpResponseMessage Post(WebHookPayloadModel model)
        {
            var messageString = JsonConvert.SerializeObject(model, Formatting.Indented);
            Debug.WriteLine(messageString);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }

    public class RequestChangesModel
    {
        [Required, DataMember(IsRequired = true)]
        public int RequestId { get; set; }

        public string SubServiceName { get; set; }

        public string SubServiceTypeName { get; set; }

        public string PointOfInterestName { get; set; }

        [Required, DataMember(IsRequired = true)]
        public string Operation { get; set; }

        public string ChangedBy { get; set; }
    }

    public class StayChangesModel
    {
        [Required, DataMember(IsRequired = true)]
        public int StayId { get; set; }

        [Required, DataMember(IsRequired = true)]
        public string Operation { get; set; }

        public string Changes { get; set; }

        public string ChangedBy { get; set; }
    }

    public class WebHookPayloadModel
    {
        public string DocumentType { get; set; }

        public RequestChangesModel Request { get; set; }

        public StayChangesModel Stay { get; set; }
    }
}
