using Newtonsoft.Json.Linq;

namespace BGuest.Integration.Api.Client
{
    public class SubServiceTypeDto
    {
        /// <summary>
        /// Sub service type id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Sub service type name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the SubServiceTypeDto class.
        /// </summary>
        public SubServiceTypeDto()
        {
        }
        
        ///// <summary>
        ///// Deserialize the object
        ///// </summary>
        //public virtual void DeserializeJson(JToken inputObject)
        //{
        //    if (inputObject != null && inputObject.Type != JTokenType.Null)
        //    {
        //        JToken idValue = inputObject["id"];
        //        if (idValue != null && idValue.Type != JTokenType.Null)
        //        {
        //            this.Id = ((string)idValue);
        //        }
        //        JToken nameValue = inputObject["name"];
        //        if (nameValue != null && nameValue.Type != JTokenType.Null)
        //        {
        //            this.Name = ((string)nameValue);
        //        }
        //    }
        //}
    }
}
