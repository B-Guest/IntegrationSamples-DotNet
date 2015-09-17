using System.ComponentModel.DataAnnotations;

namespace BGuest.Samples.Integration.Models
{
    public class RequestChangesModel
    {
        [Required]
        public int RequestId { get; set; }

        public string SubServiceName { get; set; }

        public string SubServiceTypeName { get; set; }

        public string PointOfInterestName { get; set; }

        [Required]
        public string Operation { get; set; }

        [Required]
        public string ChangedBy { get; set; }
    }
}