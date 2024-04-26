namespace CallCenter.DTO
{
    public class EventDto
    {
        public string AgentId { get; set; }
        public string AgentName { get; set; }
        public DateTime TimeStampUtc { get; set; }
        public string Action { get; set; }
        public List<Guid> QueueIds { get; set; }
    }
}
