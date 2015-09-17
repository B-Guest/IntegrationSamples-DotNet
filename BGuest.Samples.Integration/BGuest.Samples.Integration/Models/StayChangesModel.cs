using System.ComponentModel.DataAnnotations;

namespace BGuest.Samples.Integration.Models
{
    public class StayChangesModel
    {
        [Required]
        public int StayId { get; set; }

        [Required]
        public string Operation { get; set; }

        [Required]
        public string Changes { get; set; }

        [Required]
        public string ChangedBy { get; set; }
    }
}