﻿using System;

namespace BGuest.Integration.Api.Client
{
    public class StayReservationDto
    {
        /// <summary>
        /// True if the guest is allowed to perform express checkout
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
        /// Optional. External key for this reservation/stay as imported
        /// </summary>
        public string ExternalKey { get; set; }

        /// <summary>
        /// Guest info
        /// </summary>
        public GuestDto Guest { get; set; }

        /// <summary>
        /// Reservation id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Required. Indicated if the breakfast is included on the stay
        /// </summary>
        public bool IsBreakfastIncluded { get; set; }

        /// <summary>
        /// Required. If true the guest is checked in
        /// </summary>
        public bool IsCheckedIn { get; set; }

        /// <summary>
        /// True if stay/reservation was imported into bguest
        /// </summary>
        public bool IsImported { get; set; }

        /// <summary>
        /// Stay period end date
        /// </summary>
        public DateTimeOffset PeriodEnd { get; set; }

        /// <summary>
        /// Stay period start date
        /// </summary>
        public DateTimeOffset PeriodStart { get; set; }

        /// <summary>
        /// Optional. Reservation code
        /// </summary>
        public string Reservation { get; set; }

        /// <summary>
        /// Guest email address as stated on the imported
        /// reservation/stay
        /// </summary>
        public string ReservationGuestEmail { get; set; }

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
        ///// Initializes a new instance of the StayReservationDto class.
        ///// </summary>
        //public StayReservationDto()
        //{
        //}
        
        ///// <summary>
        ///// Initializes a new instance of the StayReservationDto class with
        ///// required arguments.
        ///// </summary>
        //public StayReservationDto(bool isCheckedIn, bool isBreakfastIncluded)
        //    : this()
        //{
        //    this.IsCheckedIn = isCheckedIn;
        //    this.IsBreakfastIncluded = isBreakfastIncluded;
        //}
        
        ///// <summary>
        ///// Deserialize the object
        ///// </summary>
        //public virtual void DeserializeJson(JToken inputObject)
        //{
        //    if (inputObject != null && inputObject.Type != JTokenType.Null)
        //    {
        //        JToken allowExpressCheckoutValue = inputObject["allowExpressCheckout"];
        //        if (allowExpressCheckoutValue != null && allowExpressCheckoutValue.Type != JTokenType.Null)
        //        {
        //            this.AllowExpressCheckout = ((bool)allowExpressCheckoutValue);
        //        }
        //        JToken currentBillCurrencyValue = inputObject["currentBillCurrency"];
        //        if (currentBillCurrencyValue != null && currentBillCurrencyValue.Type != JTokenType.Null)
        //        {
        //            this.CurrentBillCurrency = ((string)currentBillCurrencyValue);
        //        }
        //        JToken currentBillDateValue = inputObject["currentBillDate"];
        //        if (currentBillDateValue != null && currentBillDateValue.Type != JTokenType.Null)
        //        {
        //            this.CurrentBillDate = ((DateTimeOffset)currentBillDateValue);
        //        }
        //        JToken currentBillValueValue = inputObject["currentBillValue"];
        //        if (currentBillValueValue != null && currentBillValueValue.Type != JTokenType.Null)
        //        {
        //            this.CurrentBillValue = ((double)currentBillValueValue);
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
        //        JToken idValue = inputObject["id"];
        //        if (idValue != null && idValue.Type != JTokenType.Null)
        //        {
        //            this.Id = ((int)idValue);
        //        }
        //        JToken isBreakfastIncludedValue = inputObject["isBreakfastIncluded"];
        //        if (isBreakfastIncludedValue != null && isBreakfastIncludedValue.Type != JTokenType.Null)
        //        {
        //            this.IsBreakfastIncluded = ((bool)isBreakfastIncludedValue);
        //        }
        //        JToken isCheckedInValue = inputObject["isCheckedIn"];
        //        if (isCheckedInValue != null && isCheckedInValue.Type != JTokenType.Null)
        //        {
        //            this.IsCheckedIn = ((bool)isCheckedInValue);
        //        }
        //        JToken isImportedValue = inputObject["isImported"];
        //        if (isImportedValue != null && isImportedValue.Type != JTokenType.Null)
        //        {
        //            this.IsImported = ((bool)isImportedValue);
        //        }
        //        JToken periodEndValue = inputObject["periodEnd"];
        //        if (periodEndValue != null && periodEndValue.Type != JTokenType.Null)
        //        {
        //            this.PeriodEnd = ((DateTimeOffset)periodEndValue);
        //        }
        //        JToken periodStartValue = inputObject["periodStart"];
        //        if (periodStartValue != null && periodStartValue.Type != JTokenType.Null)
        //        {
        //            this.PeriodStart = ((DateTimeOffset)periodStartValue);
        //        }
        //        JToken reservationValue = inputObject["reservation"];
        //        if (reservationValue != null && reservationValue.Type != JTokenType.Null)
        //        {
        //            this.Reservation = ((string)reservationValue);
        //        }
        //        JToken reservationGuestEmailValue = inputObject["reservationGuestEmail"];
        //        if (reservationGuestEmailValue != null && reservationGuestEmailValue.Type != JTokenType.Null)
        //        {
        //            this.ReservationGuestEmail = ((string)reservationGuestEmailValue);
        //        }
        //        JToken roomValue = inputObject["room"];
        //        if (roomValue != null && roomValue.Type != JTokenType.Null)
        //        {
        //            this.Room = ((string)roomValue);
        //        }
        //    }
        //}
    }
}
