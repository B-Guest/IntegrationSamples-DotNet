using System;
using System.Collections.Generic;

namespace BGuest.Integration.Api.Client
{
    public class RequestDto
    {
        /// <summary>
        /// Optional. Additional information from Request
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Optional. Date when Request state was changed to "Canceled"
        /// </summary>
        public DateTimeOffset? CanceledOn { get; set; }

        /// <summary>
        /// List of Categories if Request has SubService
        /// </summary>
        public IList<RequestCategoryDto> Categories { get; set; }

        /// <summary>
        /// Optional. Date when Request state was changed to "Completed"
        /// </summary>
        public DateTimeOffset? CompletedOn { get; set; }

        /// <summary>
        /// Optional. The request currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Date to when the Request is expected (DEPRECATED - use
        /// ExpectdForLocalTime)
        /// </summary>
        [Obsolete]
        public DateTimeOffset ExpectedFor { get; set; }

        /// <summary>
        /// Date to when the Request is expected in hotel local time
        /// </summary>
        public DateTimeOffset ExpectedForLocalTime { get; set; }

        /// <summary>
        /// flag to determine if the Request is for express delivery
        /// </summary>
        public bool ExpressDelivery { get; set; }

        /// <summary>
        /// Optional. The request's external system key
        /// </summary>
        public string ExternalKey { get; set; }

        /// <summary>
        /// The guest
        /// </summary>
        public GuestDto Guest { get; set; }

        /// <summary>
        /// Optional. Comments from Guest
        /// </summary>
        public string GuestComments { get; set; }

        /// <summary>
        /// Optional. Notes from Hotel
        /// </summary>
        public string HotelComments { get; set; }

        /// <summary>
        /// Request Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Optional. Date when Request was Integrated on PMS
        /// </summary>
        public DateTimeOffset? IntegratedOn { get; set; }

        /// <summary>
        /// flag that determines if the Request is integrated on PMS
        /// </summary>
        public bool IsIntegratedOnPms { get; set; }

        /// <summary>
        /// flag that determines if any Request change was checked by
        /// Guest
        /// </summary>
        public bool IsReadByGuest { get; set; }

        /// <summary>
        /// Optional. Model of Request's Point of Interest if applicable
        /// </summary>
        public PointOfInterestDto PointOfInterest { get; set; }

        /// <summary>
        /// Optional. Date when Request state was changed to "Ready"
        /// </summary>
        public DateTimeOffset? ReadyOn { get; set; }

        /// <summary>
        /// Optional. Date of creation
        /// </summary>
        public DateTimeOffset? RequestedOn { get; set; }

        /// <summary>
        /// Room number of the request
        /// </summary>
        public string Room { get; set; }

        /// <summary>
        /// Optional. Date when Request state was changed to "Started"
        /// </summary>
        public DateTimeOffset? StartedOn { get; set; }

        /// <summary>
        /// Current state of Request (Canceled = -2;
        /// PendingStayValidation = -1; New = 0; Started = 1; Ready = 2;
        /// Completed = 3)
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// Optional. Model of Request's SubService if applicable
        /// </summary>
        public SubServiceDto SubService { get; set; }

        ///// <summary>
        ///// Initializes a new instance of the RequestDto class.
        ///// </summary>
        //public RequestDto()
        //{
        //    this.Categories = new List<RequestCategoryDto>();
        //}
        
        ///// <summary>
        ///// Deserialize the object
        ///// </summary>
        //public virtual void DeserializeJson(JToken inputObject)
        //{
        //    if (inputObject != null && inputObject.Type != JTokenType.Null)
        //    {
        //        JToken additionalInfoValue = inputObject["additionalInfo"];
        //        if (additionalInfoValue != null && additionalInfoValue.Type != JTokenType.Null)
        //        {
        //            this.AdditionalInfo = ((string)additionalInfoValue);
        //        }
        //        JToken canceledOnValue = inputObject["canceledOn"];
        //        if (canceledOnValue != null && canceledOnValue.Type != JTokenType.Null)
        //        {
        //            this.CanceledOn = ((DateTimeOffset)canceledOnValue);
        //        }
        //        JToken categoriesSequence = ((JToken)inputObject["categories"]);
        //        if (categoriesSequence != null && categoriesSequence.Type != JTokenType.Null)
        //        {
        //            foreach (JToken categoriesValue in ((JArray)categoriesSequence))
        //            {
        //                RequestCategoryDto requestCategoryDto = new RequestCategoryDto();
        //                requestCategoryDto.DeserializeJson(categoriesValue);
        //                this.Categories.Add(requestCategoryDto);
        //            }
        //        }
        //        JToken completedOnValue = inputObject["completedOn"];
        //        if (completedOnValue != null && completedOnValue.Type != JTokenType.Null)
        //        {
        //            this.CompletedOn = ((DateTimeOffset)completedOnValue);
        //        }
        //        JToken currencyValue = inputObject["currency"];
        //        if (currencyValue != null && currencyValue.Type != JTokenType.Null)
        //        {
        //            this.Currency = ((string)currencyValue);
        //        }
        //        JToken expectedForValue = inputObject["expectedFor"];
        //        if (expectedForValue != null && expectedForValue.Type != JTokenType.Null)
        //        {
        //            this.ExpectedFor = ((DateTimeOffset)expectedForValue);
        //        }
        //        JToken expectedForLocalTimeValue = inputObject["expectedForLocalTime"];
        //        if (expectedForLocalTimeValue != null && expectedForLocalTimeValue.Type != JTokenType.Null)
        //        {
        //            this.ExpectedForLocalTime = ((DateTimeOffset)expectedForLocalTimeValue);
        //        }
        //        JToken expressDeliveryValue = inputObject["expressDelivery"];
        //        if (expressDeliveryValue != null && expressDeliveryValue.Type != JTokenType.Null)
        //        {
        //            this.ExpressDelivery = ((bool)expressDeliveryValue);
        //        }
        //        JToken externalKeyValue = inputObject["externalKey"];
        //        if (externalKeyValue != null && externalKeyValue.Type != JTokenType.Null)
        //        {
        //            this.ExternalKey = ((string)externalKeyValue);
        //        }
        //        JToken guestValue = inputObject["guest"];
        //        if (guestValue != null && guestValue.Type != JTokenType.Null)
        //        {
        //            GuestDto guestDto = new GuestDto();
        //            guestDto.DeserializeJson(guestValue);
        //            this.Guest = guestDto;
        //        }
        //        JToken guestCommentsValue = inputObject["guestComments"];
        //        if (guestCommentsValue != null && guestCommentsValue.Type != JTokenType.Null)
        //        {
        //            this.GuestComments = ((string)guestCommentsValue);
        //        }
        //        JToken hotelCommentsValue = inputObject["hotelComments"];
        //        if (hotelCommentsValue != null && hotelCommentsValue.Type != JTokenType.Null)
        //        {
        //            this.HotelComments = ((string)hotelCommentsValue);
        //        }
        //        JToken idValue = inputObject["id"];
        //        if (idValue != null && idValue.Type != JTokenType.Null)
        //        {
        //            this.Id = ((int)idValue);
        //        }
        //        JToken integratedOnValue = inputObject["integratedOn"];
        //        if (integratedOnValue != null && integratedOnValue.Type != JTokenType.Null)
        //        {
        //            this.IntegratedOn = ((DateTimeOffset)integratedOnValue);
        //        }
        //        JToken isIntegratedOnPmsValue = inputObject["isIntegratedOnPms"];
        //        if (isIntegratedOnPmsValue != null && isIntegratedOnPmsValue.Type != JTokenType.Null)
        //        {
        //            this.IsIntegratedOnPms = ((bool)isIntegratedOnPmsValue);
        //        }
        //        JToken isReadByGuestValue = inputObject["isReadByGuest"];
        //        if (isReadByGuestValue != null && isReadByGuestValue.Type != JTokenType.Null)
        //        {
        //            this.IsReadByGuest = ((bool)isReadByGuestValue);
        //        }
        //        JToken pointOfInterestValue = inputObject["pointOfInterest"];
        //        if (pointOfInterestValue != null && pointOfInterestValue.Type != JTokenType.Null)
        //        {
        //            PointOfInterestDto pointOfInterestDto = new PointOfInterestDto();
        //            pointOfInterestDto.DeserializeJson(pointOfInterestValue);
        //            this.PointOfInterest = pointOfInterestDto;
        //        }
        //        JToken readyOnValue = inputObject["readyOn"];
        //        if (readyOnValue != null && readyOnValue.Type != JTokenType.Null)
        //        {
        //            this.ReadyOn = ((DateTimeOffset)readyOnValue);
        //        }
        //        JToken requestedOnValue = inputObject["requestedOn"];
        //        if (requestedOnValue != null && requestedOnValue.Type != JTokenType.Null)
        //        {
        //            this.RequestedOn = ((DateTimeOffset)requestedOnValue);
        //        }
        //        JToken roomValue = inputObject["room"];
        //        if (roomValue != null && roomValue.Type != JTokenType.Null)
        //        {
        //            this.Room = ((string)roomValue);
        //        }
        //        JToken startedOnValue = inputObject["startedOn"];
        //        if (startedOnValue != null && startedOnValue.Type != JTokenType.Null)
        //        {
        //            this.StartedOn = ((DateTimeOffset)startedOnValue);
        //        }
        //        JToken stateValue = inputObject["state"];
        //        if (stateValue != null && stateValue.Type != JTokenType.Null)
        //        {
        //            this.State = ((int)stateValue);
        //        }
        //        JToken subServiceValue = inputObject["subService"];
        //        if (subServiceValue != null && subServiceValue.Type != JTokenType.Null)
        //        {
        //            SubServiceDto subServiceDto = new SubServiceDto();
        //            subServiceDto.DeserializeJson(subServiceValue);
        //            this.SubService = subServiceDto;
        //        }
        //    }
        //}
    }

    /// <summary>
    /// A checkin request
    /// </summary>
    public class CheckInRequestDto
    {
        /// <summary>
        /// CheckIn Request Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Checkin date
        /// </summary>
        public DateTimeOffset CheckInDate { get; set; }
        /// <summary>
        /// Checkout date
        /// </summary>
        public DateTimeOffset CheckOutDate { get; set; }
        /// <summary>
        /// Expected arrival time to checkin.
        /// </summary>
        public DateTimeOffset? ExpectedArrivalTime { get; set; }
        /// <summary>
        /// Reservation number.
        /// </summary>
        public string Reservation { get; set; }
        /// <summary>
        /// Reservation External Key.
        /// </summary>
        public string ReservationExternalKey { get; set; }
        /// <summary>
        /// Reservation first name.
        /// </summary>
        public string ReservationFirstName { get; set; }
        /// <summary>
        /// Reservation last name.
        /// </summary>
        public string ReservationLastName { get; set; }
        /// <summary>
        /// Reservation email address.
        /// </summary>
        public string ReservationEmail { get; set; }
        /// <summary>
        /// Reservation phone number.
        /// </summary>
        public string ReservationPhone { get; set; }
        /// <summary>
        /// Guest first name. (DEPRECATED) - Please use Guest.FirstName
        /// </summary>
        [Obsolete]
        public string FirstName { get; set; }
        /// <summary>
        /// Guest last name. (DEPRECATED) - Please use Guest.LastName
        /// </summary>
        [Obsolete]
        public string LastName { get; set; }
        /// <summary>
        /// Guest email address. (DEPRECATED) - Please use Guest.Email
        /// </summary>
        [Obsolete]
        public string Email { get; set; }
        /// <summary>
        /// Guest phone number. (DEPRECATED) - Please user Guest.Phone
        /// </summary>
        [Obsolete]
        public string Phone { get; set; }
        /// <summary>
        /// Guest identification card number. (DEPRECATED) - Please use Guest.Identification
        /// </summary>
        [Obsolete]
        public string GuestIdentification { get; set; }
        /// <summary>
        /// Reservation number of Guests.
        /// </summary>
        public int? NumberOfGuests { get; set; }
        /// <summary>
        /// Reservation number of Children in Group 1.
        /// Usually between 0 and 3 years age.
        /// </summary>
        public int? NumberOfChildrenGroup1 { get; set; }
        /// <summary>
        /// Reservation number of Children in Group 2.
        /// Usually between 4 and 12 years age.
        /// </summary>
        public int? NumberOfChildrenGroup2 { get; set; }
        /// <summary>
        /// Reservation number of Children in Group 2.
        /// Usually between 13 and 18 years age.
        /// </summary>
        public int? NumberOfChildrenGroup3 { get; set; }
        /// <summary>
        /// Request comments.
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTimeOffset RequestedOn { get; set; }
        /// <summary>                 
        /// CheckIn request State. Possible values: New = 0, Confirmed = 1, Rejected = -1 or Removed = -2
        /// </summary>   
        public int State { get; set; }
        /// <summary>                 
        /// Date when Request state was changed to "Confirmed"
        /// </summary>                
        public DateTimeOffset? ConfirmedOn { get; set; }
        /// <summary>
        /// Date when checkin Request state was changed to "Rejected"
        /// </summary>
        public DateTimeOffset? RejectedOn { get; set; }
        /// <summary>
        /// Date when Request state was changed to "Removed"
        /// </summary>
        public DateTimeOffset? CanceledOn { get; set; }
        /// <summary>
        /// Date when checkin Request was Integrated on PMS
        /// </summary>
        public DateTimeOffset? IntegratedOn { get; set; }
        /// <summary>
        /// flag that determines if the checkin Request is integrated on PMS
        /// </summary>
        public bool IsIntegratedOnPms { get; set; }
        /// <summary>
        /// Main guest information
        /// </summary>
        public CheckInMainGuestDto Guest { get; set; }
        /// <summary>
        /// The request's external system key
        /// </summary>
        public string ExternalKey { get; set; }
        /// <summary>
        /// The request's type. It can be Online CheckIn (1) or Frontdesk CheckIn (2)
        /// </summary>
        public int? CheckInType { get; set; }
        /// <summary>
        /// List of other guests included in Check-in process
        /// </summary>
        public IEnumerable<CheckInGuestDto> OtherGuests { get; set; }
    }
}
