using System.ComponentModel.DataAnnotations;

namespace BGuest.Samples.Integration.Models
{
    public class WebHookPayloadModel
    {
        [Required]
        public string DocumentType { get; set; }

        [Required]
        public RequestChangesModel Request { get; set; }

        [Required]
        public StayChangesModel Stay { get; set; }
    }
}