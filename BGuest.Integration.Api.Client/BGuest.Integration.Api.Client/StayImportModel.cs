using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BGuest.Integration.Api.Client
{
    /// <summary>
    /// Stay/reservation possible BGuest's states
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StayStates
    {
        /// <summary>
        /// Stay / reservation is active
        /// </summary>
        Active = 0,
        /// <summary>
        /// Stay / reservation is inactive or canceled for some reason.
        /// </summary>
        Removed = -1
    }

    public class StayImportModel
    {
        /// <summary>
        /// Required. True if the guest is allowed to perform express checkout
        /// (not used at this time)
        /// </summary>
        public bool AllowExpressCheckout { get; set; }

        /// <summary>
        /// Optional. Current bill value currency (not used at this time)
        /// </summary>
        public string CurrentBillCurrency { get; set; }

        /// <summary>
        /// Optional. Date when the current bill value was last updated (not
        /// used at this time)
        /// </summary>
        public DateTimeOffset? CurrentBillDate { get; set; }

        /// <summary>
        /// Optional. Current bill value (not used at this time)
        /// </summary>
        public double? CurrentBillValue { get; set; }

        /// <summary>
        /// Required. External system id. Place you stay/reservation ID on this
        /// field.
        /// You can refer to stays/reservations later through this
        /// key or through BGuest ID.
        /// </summary>
        public string ExternalKey { get; set; }

        /// <summary>
        /// Required. Guest email (bguest will try to match with its user list
        /// through this field)
        /// </summary>
        public string GuestEmail { get; set; }

        /// <summary>
        /// Guest first name
        /// </summary>      
        public string GuestFirstName { get; set; }

        /// <summary>
        /// Guest last name
        /// </summary>      
        public string GuestLastName { get; set; }

        /// <summary>
        /// Guest phone number
        /// </summary>      
        public string GuestPhoneNumber { get; set; }


        /// <summary>
        /// Required. Indicated if the breakfast is included on the stay
        /// </summary>
        public bool IsBreakfastIncluded { get; set; }

        /// <summary>
        /// Required. Indicates if the guest is checked in or not
        /// </summary>
        public bool IsCheckedIn { get; set; }

        /// <summary>
        /// Required. Stay period end date
        /// </summary>
        public DateTimeOffset PeriodEnd { get; set; }

        /// <summary>
        /// Required. Stay period start date
        /// </summary>
        public DateTimeOffset PeriodStart { get; set; }

        /// <summary>
        /// Optional. Reservation code
        /// </summary>
        public string Reservation { get; set; }

        /// <summary>
        /// Optional. Room number
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// Current Stay / reservation state. 
        /// Possible values are Active or Removed.
        /// </summary>
        public StayStates State { get; set; }

        ///// <summary>
        ///// Initializes a new instance of the StayImportModel class.
        ///// </summary>
        //public StayImportModel()
        //{
        //}
        
        ///// <summary>
        ///// Serialize the object
        ///// </summary>
        ///// <returns>
        ///// Returns the json model for the type StayImportModel
        ///// </returns>
        //public virtual JToken SerializeJson(JToken outputObject)
        //{
        //    if (outputObject == null)
        //    {
        //        outputObject = new JObject();
        //    }
        //    if (this.ExternalKey == null)
        //    {
        //        throw new ArgumentNullException("ExternalKey");
        //    }
        //    if (this.GuestEmail == null)
        //    {
        //        throw new ArgumentNullException("GuestEmail");
        //    }
        //    outputObject["allowExpressCheckout"] = this.AllowExpressCheckout;
        //    if (this.CurrentBillCurrency != null)
        //    {
        //        outputObject["currentBillCurrency"] = this.CurrentBillCurrency;
        //    }
        //    if (this.CurrentBillDate != null)
        //    {
        //        outputObject["currentBillDate"] = this.CurrentBillDate.Value;
        //    }
        //    if (this.CurrentBillValue != null)
        //    {
        //        outputObject["currentBillValue"] = this.CurrentBillValue.Value;
        //    }
        //    if (this.ExternalKey != null)
        //    {
        //        outputObject["externalKey"] = this.ExternalKey;
        //    }
        //    if (this.GuestEmail != null)
        //    {
        //        outputObject["guestEmail"] = this.GuestEmail;
        //    }
        //    if (this.GuestFirstName != null)
        //    {
        //        outputObject["guestFirstName"] = this.GuestFirstName;
        //    }
        //    if (this.GuestLastName != null)
        //    {
        //        outputObject["guestLastName"] = this.GuestLastName;
        //    }
        //    outputObject["isBreakfastIncluded"] = this.IsBreakfastIncluded;
        //    outputObject["isCheckedIn"] = this.IsCheckedIn;
        //    outputObject["periodEnd"] = this.PeriodEnd;
        //    outputObject["periodStart"] = this.PeriodStart;
        //    if (this.Reservation != null)
        //    {
        //        outputObject["reservation"] = this.Reservation;
        //    }
        //    if (this.Room != null)
        //    {
        //        outputObject["room"] = this.Room;
        //    }
        //    outputObject["state"] = this.State.ToString();
        //    return outputObject;
        //}
    }
}
