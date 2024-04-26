namespace CallCenter.AgentsService.Domain
{
    using CallCenter.DTO;
    public interface IAgentsDomain
    {
        public Task<AgentDto> UpdateAgent(EventDto eventDto);
    }
}
