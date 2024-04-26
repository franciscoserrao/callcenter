namespace CallCenter.AgentsService.Utils
{
    public class NotSupportedException : Exception
    {
        public NotSupportedException(string message) : base(message) { }
    }
}
