using Newtonsoft.Json.Linq;

namespace BGuest.Integration.Api.Client
{
    public class SetRequestAsIntegratedModel
    {
        /// <summary>
        /// External system key for this request
        /// </summary>
        public string ExternalKey { get; set; }

        /// <summary>
        /// Indicates that the request is integrated on the PMS system
        /// </summary>
        public bool IsIntegratedOnPms { get; set; }

        /// <summary>
        /// Initializes a new instance of the SetRequestAsIntegratedModel class.
        /// </summary>
        public SetRequestAsIntegratedModel()
        {
        }
        
        ///// <summary>
        ///// Serialize the object
        ///// </summary>
        ///// <returns>
        ///// Returns the json model for the type SetRequestAsIntegratedModel
        ///// </returns>
        //public virtual JToken SerializeJson(JToken outputObject)
        //{
        //    if (outputObject == null)
        //    {
        //        outputObject = new JObject();
        //    }
        //    if (this.ExternalKey != null)
        //    {
        //        outputObject["externalKey"] = this.ExternalKey;
        //    }
        //    if (this.IsIntegratedOnPms != null)
        //    {
        //        outputObject["isIntegratedOnPms"] = this.IsIntegratedOnPms.Value;
        //    }
        //    return outputObject;
        //}
    }

    public class SetCheckInRequestAsIntegratedModel
    {
        /// <summary>
        /// External system key for this checkin request
        /// </summary>
        public string ExternalKey { get; set; }

        /// <summary>
        /// Indicates that the checkin request is integrated on the PMS system
        /// </summary>
        public bool IsIntegratedOnPms { get; set; }

        /// <summary>
        /// Initializes a new instance of the SetCheckInRequestAsIntegratedModel class.
        /// </summary>
        public SetCheckInRequestAsIntegratedModel()
        {
        }

        ///// <summary>
        ///// Serialize the object
        ///// </summary>
        ///// <returns>
        ///// Returns the json model for the type SetCheckInRequestAsIntegratedModel
        ///// </returns>
        //public virtual JToken SerializeJson(JToken outputObject)
        //{
        //    if (outputObject == null)
        //    {
        //        outputObject = new JObject();
        //    }
        //    if (this.ExternalKey != null)
        //    {
        //        outputObject["externalKey"] = this.ExternalKey;
        //    }
        //    if (this.IsIntegratedOnPms != null)
        //    {
        //        outputObject["isIntegratedOnPms"] = this.IsIntegratedOnPms.Value;
        //    }
        //    return outputObject;
        //}
    }
}
