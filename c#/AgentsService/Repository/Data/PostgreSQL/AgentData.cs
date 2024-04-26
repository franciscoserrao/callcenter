namespace CallCenter.AgentsService.Repository.Data.PostgreSQL
{
    using CallCenter.DTO.Enum;
    public class AgentData
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public AgentState state { get; set; }
        public List<Guid> skills { get; set; }
    }
}
