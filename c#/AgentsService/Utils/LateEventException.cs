namespace CallCenter.AgentsService.Utils
{
    public class LateEventException : Exception
    {
        public LateEventException(string message) : base(message) { }
    }
}
