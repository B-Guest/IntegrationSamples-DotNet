namespace BGuest.Integration.Console.Net20.Model
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