
namespace BGuest.Integration.Api.Client
{
    public class GuestDto
    {
        /// <summary>
        /// Optional. Guest email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Optional. First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Optional. Guest id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Optional. Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Username if the guest is a bguest user
        /// </summary>
        public string UserName { get; set; }

        ///// <summary>
        ///// Initializes a new instance of the GuestDto class.
        ///// </summary>
        //public GuestDto()
        //{
        //}
        
        ///// <summary>
        ///// Deserialize the object
        ///// </summary>
        //public virtual void DeserializeJson(JToken inputObject)
        //{
        //    if (inputObject != null && inputObject.Type != JTokenType.Null)
        //    {
        //        JToken emailValue = inputObject["email"];
        //        if (emailValue != null && emailValue.Type != JTokenType.Null)
        //        {
        //            this.Email = ((string)emailValue);
        //        }
        //        JToken firstNameValue = inputObject["firstName"];
        //        if (firstNameValue != null && firstNameValue.Type != JTokenType.Null)
        //        {
        //            this.FirstName = ((string)firstNameValue);
        //        }
        //        JToken idValue = inputObject["id"];
        //        if (idValue != null && idValue.Type != JTokenType.Null)
        //        {
        //            this.Id = ((int)idValue);
        //        }
        //        JToken lastNameValue = inputObject["lastName"];
        //        if (lastNameValue != null && lastNameValue.Type != JTokenType.Null)
        //        {
        //            this.LastName = ((string)lastNameValue);
        //        }
        //        JToken userNameValue = inputObject["userName"];
        //        if (userNameValue != null && userNameValue.Type != JTokenType.Null)
        //        {
        //            this.UserName = ((string)userNameValue);
        //        }
        //    }
        //}
    }
}
