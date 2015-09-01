using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace BGuest.Samples.Integration.Controllers
{
    [RoutePrefix("webhooks")]
    public class WebHooksController : ApiController
    {

        [Route("requestchanges")]
        [HttpPost]
        public HttpResponseMessage Post(RequestChangesModel model)
        {
            Debug.WriteLine($"Request {model.Operation}:");
            Debug.WriteLine($"RequestId: {model.RequestId}, SubService: '{model.SubServiceName}', " +
                            $"SubServiceType: '{model.SubServiceTypeName}', " +
                            $"PointOfInterest: '{model.PointOfInterestName}'.");
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
    }
}
