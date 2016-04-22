namespace BGuest.Integration.Console.Model
{
    public class StayImportResultDto
    {
        public string ExternalKey { get; set; }

        public string GuestEmail { get; set; }

        public string Id { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}