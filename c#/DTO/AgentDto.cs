namespace CallCenter.DTO
{
    using DTO.Enum;
    public class AgentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AgentState State { get; set; }
        public List<Guid> Skills { get; set; }
    }
}
