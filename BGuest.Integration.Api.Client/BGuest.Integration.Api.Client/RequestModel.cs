using System;
using System.ComponentModel.DataAnnotations;

namespace BGuest.Integration.Api.Client
{
    public class RequestModel
    {
        [Required]
        public int Id { get; set; }
        public DateTimeOffset? RequestedOn { get; set; }
        public DateTimeOffset? ExpectedFor { get; set; }
        public DateTimeOffset? ExpectedForLocalTime { get; set; }
        public string GuestComments { get; set; }
        public string HotelComments { get; set; }
        public bool ExpressDelivery { get; set; }
        public int State { get; set; }
        public DateTimeOffset? StartedOn { get; set; }
        public DateTimeOffset? ReadyOn { get; set; }
        public DateTimeOffset? CompletedOn { get; set; }
        public DateTimeOffset? CanceledOn { get; set; }
        public DateTimeOffset? IntegratedOn { get; set; }
        public bool IsIntegratedOnPms { get; set; }
        public bool IsReadByGuest { get; set; }
        public string AdditionalInfo { get; set; }
        public string Currency { get; set; }
        public string Room { get; set; }
        public string ExternalKey { get; set; }
    }
}