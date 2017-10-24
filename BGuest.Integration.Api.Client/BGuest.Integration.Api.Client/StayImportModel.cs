using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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

    /// <summary>
    /// Stay/reservation possible BGuest's states
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GuestGender
    {
        /// <summary>
        /// Guest gender is unknown
        /// </summary>
        None = 0,
        /// <summary>
        /// Guest is Male
        /// </summary>
        Male = 1,
        /// <summary>
        /// Guest is Female
        /// </summary>
        Female = 2,
    }


    /// <summary>
    /// Stay/reservation other guest model
    /// </summary>
    public class StayImportOtherGuestModel
    {
        /// <summary>
        /// Guest email
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
        [StringLength(255)]
        public string GuestPhoneNumber { get; set; }
        /// <summary>
        /// Guest country. Two characters ISO-Alpha-2 code.
        /// </summary>
        [StringLength(2)]
        public string GuestCountryCode { get; set; }
        /// <summary>
        /// Guest birth date.
        /// </summary>
        public DateTime? GuestBirthDate { get; set; }
        /// <summary>
        /// Guest gender.
        /// Possible values are None, Male or Female
        /// </summary>
        public GuestGender? GuestGender { get; set; }

        /// <summary>
        /// External system Guest id. Place your guest/cardex ID on this field. 
        /// You can refer to guest/cardex later through this key.
        /// </summary>
        public string ExternalGuestKey { get; set; }

        /// <summary>
        /// Guest title. 
        /// Ex: Sir, Ms, Madam, Mrs, Miss.
        /// </summary>
        public string GuestTitle { get; set; }

        /// <summary>
        /// Guest Address. 
        /// </summary>
        public string GuestAddress { get; set; }

        /// <summary>
        /// Guest Address Number.
        /// </summary>
        public string GuestAddressNumber { get; set; }

        /// <summary>
        /// Guest Address Country. 
        /// </summary>
        public string GuestAddressCountry { get; set; }

        /// <summary>
        /// Guest Address ZipCode. 
        /// </summary>
        public string GuestZipCode { get; set; }

        /// <summary>
        /// Guest Address City. 
        /// </summary>
        public string GuestCity { get; set; }

        /// <summary>
        /// Guest identification card number. 
        /// </summary>
        public string GuestIdentification { get; set; }

        /// <summary>
        /// Guest identification card expiration date. 
        /// </summary>
        public DateTime? GuestIdentificationExpiryDate { get; set; }

        /// <summary>
        /// Guest identification card issue date. 
        /// </summary>
        public DateTime? GuestIdentificationIssueDate { get; set; }

        /// <summary>
        /// Guest identification card issuer/issue place.
        /// </summary>
        public string GuestIdentificationCardIssuer { get; set; }

        /// <summary>
        /// Guest identification card type. 
        /// Possible values are 1 (IdentificationCard) and 2 (Passport).
        /// </summary>
        public int? GuestIdentificationCardType { get; set; }

        /// <summary>
        /// Guest OtherNames. 
        /// </summary>
        public string GuestOtherNames { get; set; }

        /// <summary>
        /// Guest Birth Place. 
        /// City where the guest was born.
        /// </summary>
        public string GuestBirthPlace { get; set; }
    }

    public class StayImportRoomModel
    {
        /// <summary>
        /// Room category code
        /// </summary>
        public string CategoryCode { get; set; }
        /// <summary>
        /// Room category description
        /// </summary>
        public string CategoryDescription { get; set; }
        /// <summary>
        /// Room capacity
        /// </summary>
        public int? Capacity { get; set; }
        /// <summary>
        /// Room number
        /// </summary>
        public string RoomNumber { get; set; }
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
        /// <summary>
        /// Regimen type.
        /// </summary>
        [StringLength(255)]
        public string RegimenType { get; set; }
        /// <summary>
        /// Regimen type description
        /// </summary>
        [StringLength(1024)]
        public string RegimenTypeDescription { get; set; }
        /// <summary>
        /// Number of guests.
        /// </summary>
        public int? NumberOfGuests { get; set; }
        /// <summary>
        /// Guest email 
        /// </summary>
        /// <summary>
        /// Guest country. Two characters ISO-Alpha-2 code.
        /// </summary>
        [StringLength(2)]
        public string GuestCountryCode { get; set; }
        /// <summary>
        /// Guest birth date.
        /// </summary>
        public DateTime? GuestBirthDate { get; set; }
        /// <summary>
        /// Guest gender.
        /// Possible values are None, Male or Female
        /// </summary>
        public GuestGender? GuestGender { get; set; }

        /// <summary>
        /// Number of children from Group 1. 
        /// Usually age between 0 and 3.
        /// </summary>
        public int? NumberOfChildrenGroup1 { get; set; }

        /// <summary>
        /// Number of children from Group 2. 
        /// Usually age between 4 and 12.
        /// </summary>
        public int? NumberOfChildrenGroup2 { get; set; }

        /// <summary>
        /// Number of children from Group 3. 
        /// Usually age between 13 and 18.
        /// </summary>
        public int? NumberOfChildrenGroup3 { get; set; }

        /// <summary>
        /// External system Guest id. Place your guest/cardex ID on this field. 
        /// You can refer to guest/cardex later through this key.
        /// </summary>
        public string ExternalGuestKey { get; set; }

        /// <summary>
        /// Guest title. 
        /// Ex: Sir, Ms, Madam, Mrs, Miss.
        /// To be used in E-Mails, SMS, Messenger or other communication between the Hotel and Guest
        /// </summary>
        public string GuestTitle { get; set; }

        /// <summary>
        /// Vehicle Plate Number. 
        /// </summary>
        public string VehiclePlateNumber { get; set; }

        /// <summary>
        /// Guest Vat Number. 
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// Guest Address. 
        /// </summary>
        public string GuestAddress { get; set; }

        /// <summary>
        /// Guest Address Number.
        /// </summary>
        public string GuestAddressNumber { get; set; }

        /// <summary>
        /// Guest Address Country. 
        /// </summary>
        public string GuestAddressCountry { get; set; }

        /// <summary>
        /// Guest Address ZipCode. 
        /// </summary>
        public string GuestZipCode { get; set; }

        /// <summary>
        /// Guest Address City. 
        /// </summary>
        public string GuestCity { get; set; }

        /// <summary>
        /// Stay/Reservation comments.
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Guest identification card number. 
        /// </summary>
        public string GuestIdentification { get; set; }

        /// <summary>
        /// Guest identification card expiration date. 
        /// </summary>
        public DateTime? GuestIdentificationExpiryDate { get; set; }

        /// <summary>
        /// Guest identification card issue date. 
        /// </summary>
        public DateTime? GuestIdentificationIssueDate { get; set; }

        /// <summary>
        /// Guest identification card issuer/issue place.
        /// </summary>
        public string GuestIdentificationCardIssuer { get; set; }

        /// <summary>
        /// Guest identification card type. 
        /// Possible values are 1 (IdentificationCard) and 2 (Passport).
        /// </summary>
        public int? GuestIdentificationCardType { get; set; }

        /// <summary>
        /// Guest OtherNames. 
        /// </summary>
        public string GuestOtherNames { get; set; }

        /// <summary>
        /// Guest Birth Place. 
        /// City where the guest was born.
        /// </summary>
        public string GuestBirthPlace { get; set; }

        /// <summary>
        /// OtherGuests. 
        /// List of other guest in the reservation.
        /// </summary>
        public IEnumerable<StayImportOtherGuestModel> OtherGuests { get; set; }

        /// <summary>
        /// Reservation Rooms. 
        /// List of rooms in the reservation.
        /// </summary>
        public IEnumerable<StayImportRoomModel> Rooms { get; set; }


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
