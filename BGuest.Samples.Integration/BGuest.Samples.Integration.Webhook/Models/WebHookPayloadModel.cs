using System.ComponentModel.DataAnnotations;

namespace BGuest.Samples.Integration.Webhook.Models
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