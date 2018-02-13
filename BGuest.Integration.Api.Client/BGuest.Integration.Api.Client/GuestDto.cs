
using System;
using System.Collections.Generic;

namespace BGuest.Integration.Api.Client
{

    public class GuestDto
    {
        /// <summary>
        /// Guest id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Username if the guest is a bguest user
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Guest email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
    }

    public class CheckInGuestDto: GuestDto
    {
        /// <summary>
        /// Guest identification card number.
        /// </summary>
        public string Identification { get; set; }
        /// <summary>
        /// Identification card number expiration date.
        /// </summary>
        public DateTime? IdentificationExpiryDate { get; set; }
        /// <summary>
        /// Identification card number issue date.
        /// </summary>
        public DateTime? IdentificationIssueDate { get; set; }
        /// <summary>
        /// Guest's identification card front image url
        /// </summary>
        public string GuestIdentificationCardFrontImageUrl { get; set; }
        /// <summary>
        /// Guest's identification card back image url
        /// </summary>
        public string GuestIdentificationCardBackImageUrl { get; set; }
        /// <summary>
        /// Guest's identification card type. Possible values: 1 - Identification Card, 2 - Passport.
        /// </summary>
        public int? GuestIdentificationCardType { get; set; }
        /// <summary>
        /// Guest identification card issuer/issue place.
        /// </summary>
        public string GuestIdentificationCardIssuer { get; set; }
        /// <summary>
        /// Guest birth date.
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// Guest country code.
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// Guest's address.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Guest's address country.
        /// </summary>
        public string AddressCountry { get; set; }
        /// <summary>
        /// Guest Address Number.
        /// </summary>
        public string AddressNumber { get; set; }
        /// <summary>
        /// Guest's zipcode.
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// Guest's city.
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Guest phone number
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Guest's gender. 1 - Male, 2 - Female
        /// </summary>
        public int? Gender { get; set; }
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
        /// Guest other names. 
        /// </summary>
        public string GuestOtherNames { get; set; }
        /// <summary>
        /// Guest Birth Place. 
        /// City where the guest was born.
        /// </summary>
        public string GuestBirthPlace { get; set; }

        /// <summary>
        /// Dictionary with optional fields for check-in process by hotel
        /// </summary>
        public Dictionary<string, string> CustomFields { get; set; }
    }

    /// <summary>
    /// Additional fields of Check-In main guest
    /// </summary>
    public class CheckInMainGuestDto : CheckInGuestDto
    {
        /// <summary>
        /// Guest Vehicle Plate Number. 
        /// </summary>
        public string VehiclePlateNumber { get; set; }
        /// <summary>
        /// Guest Vat Number. 
        /// </summary>
        public string VatNumber { get; set; }
    }
}
