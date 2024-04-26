namespace CallCenter.AgentsService.Repository
{
    using CallCenter.DTO;

    public interface IAgentsRepository
    {
        public Task<AgentDto> GetAgentDtoById(string id);
        public Task<AgentDto> UpdateAgent(AgentDto agentDto);
    }
}
