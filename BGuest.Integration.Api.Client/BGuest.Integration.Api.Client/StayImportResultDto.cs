using System;

namespace BGuest.Integration.Api.Client
{
    public class StayImportResultDto
    {
        /// <summary>
        /// Required. External key as provided on the import structure
        /// </summary>
        public string ExternalKey { get; set; }

        /// <summary>
        /// Required. Guest email as provided on the import structure
        /// </summary>
        public string GuestEmail { get; set; }

        /// <summary>
        /// Required. BGuest ID for the stay
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Message for import result
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Boolean that states if importation was successful
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Initializes a new instance of the StayImportResultDto class.
        /// </summary>
        public StayImportResultDto()
        {
        }
        
        ///// <summary>
        ///// Initializes a new instance of the StayImportResultDto class with
        ///// required arguments.
        ///// </summary>
        //public StayImportResultDto(string id, string guestEmail, string externalKey)
        //    : this()
        //{
        //    if (id == null)
        //    {
        //        throw new ArgumentNullException("id");
        //    }
        //    if (guestEmail == null)
        //    {
        //        throw new ArgumentNullException("guestEmail");
        //    }
        //    if (externalKey == null)
        //    {
        //        throw new ArgumentNullException("externalKey");
        //    }
        //    this.Id = id;
        //    this.GuestEmail = guestEmail;
        //    this.ExternalKey = externalKey;
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
        //        JToken guestEmailValue = inputObject["guestEmail"];
        //        if (guestEmailValue != null && guestEmailValue.Type != JTokenType.Null)
        //        {
        //            this.GuestEmail = ((string)guestEmailValue);
        //        }
        //        JToken idValue = inputObject["id"];
        //        if (idValue != null && idValue.Type != JTokenType.Null)
        //        {
        //            this.Id = ((string)idValue);
        //        }
        //        JToken messageValue = inputObject["message"];
        //        if (messageValue != null && messageValue.Type != JTokenType.Null)
        //        {
        //            this.Message = ((string)messageValue);
        //        }
        //        JToken successValue = inputObject["success"];
        //        if (successValue != null && successValue.Type != JTokenType.Null)
        //        {
        //            this.Success = ((bool)successValue);
        //        }
        //    }
        //}
    }
}
