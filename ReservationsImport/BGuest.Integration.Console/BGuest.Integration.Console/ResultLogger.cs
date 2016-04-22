using BGuest.Integration.Console.Model;

namespace BGuest.Integration.Console
{
    public abstract class ResultLogger
    {
        public abstract void AddResponse(StayImportResultDto response);
        public override abstract string ToString();
    }
}