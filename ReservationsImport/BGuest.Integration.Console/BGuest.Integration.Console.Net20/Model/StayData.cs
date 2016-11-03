using System;

namespace BGuest.Integration.Console.Net20.Model
{
    public class StayData //: StayImportModel
    {
        public string HotelId { get; set; }

        public bool AllowExpressCheckout { get; set; }

        public string CurrentBillCurrency { get; set; }

        public DateTime? CurrentBillDate { get; set; }

        public double? CurrentBillValue { get; set; }

        public string ExternalKey { get; set; }

        public string GuestEmail { get; set; }

        public string GuestFirstName { get; set; }

        public string GuestLastName { get; set; }

        public string GuestPhoneNumber { get; set; }

        public bool IsBreakfastIncluded { get; set; }

        public bool IsCheckedIn { get; set; }

        public DateTime PeriodEnd { get; set; }

        public DateTime PeriodStart { get; set; }

        public string Reservation { get; set; }

        public string Room { get; set; }

        public StayStates State { get; set; }
        public string RegimenType { get; set; }
        public string RegimenTypeDescription { get; set; }
        public int? NumberOfGuests { get; set; }
    }
}