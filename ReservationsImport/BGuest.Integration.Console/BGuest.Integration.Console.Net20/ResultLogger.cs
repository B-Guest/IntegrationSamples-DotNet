using BGuest.Integration.Console.Net20.Model;

namespace BGuest.Integration.Console.Net20
{
    public abstract class ResultLogger
    {
        public abstract void AddResponse(StayImportResultDto response);
        public override abstract string ToString();
    }
}