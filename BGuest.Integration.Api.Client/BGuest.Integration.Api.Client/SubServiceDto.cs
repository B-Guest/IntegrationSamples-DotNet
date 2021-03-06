﻿namespace BGuest.Integration.Api.Client
{
    public class SubServiceDto
    {
        /// <summary>
        /// Optional. External system key
        /// </summary>
        public string ExternalKey { get; set; }

        /// <summary>
        /// Sub service id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Sub service name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Sub service type
        /// </summary>
        public SubServiceTypeDto SubServiceType { get; set; }

        ///// <summary>
        ///// Initializes a new instance of the SubServiceDto class.
        ///// </summary>
        //public SubServiceDto()
        //{
        //}
        
        ///// <summary>
        ///// Deserialize the object
        ///// </summary>
        //public virtual void DeserializeJson(JToken inputObject)
        //{
        //    if (inputObject != null && inputObject.Type != JTokenType.Null)
        //    {
        //        JToken externalKeyValue = inputObject["externalKey"];
        //        if (externalKeyValue != null && externalKeyValue.Type != JTokenType.Null)
        //        {
        //            this.ExternalKey = ((string)externalKeyValue);
        //        }
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
        //        JToken subServiceTypeValue = inputObject["subServiceType"];
        //        if (subServiceTypeValue != null && subServiceTypeValue.Type != JTokenType.Null)
        //        {
        //            SubServiceTypeDto subServiceTypeDto = new SubServiceTypeDto();
        //            subServiceTypeDto.DeserializeJson(subServiceTypeValue);
        //            this.SubServiceType = subServiceTypeDto;
        //        }
        //    }
        //}
    }
}
