namespace CallCenter.AgentsService.Domain
{
    using CallCenter.AgentsService.Repository;
    using CallCenter.AgentsService.Utils;
    using CallCenter.DTO;
    using DTO = CallCenter.DTO.Enum;

    public class AgentsDomain : IAgentsDomain
    {
        private readonly IAgentsRepository _agentsRepository;

        public AgentsDomain(IAgentsRepository agentsRepository)
        {
            _agentsRepository = agentsRepository;
        }

        public async Task<AgentDto> UpdateAgent(EventDto eventDto)
        {
            TimeSpan eventTime = eventDto.TimeStampUtc.TimeOfDay;
            AgentDto agentDto = await _agentsRepository.GetAgentDtoById(eventDto.AgentId);

            if (DateTime.UtcNow - eventDto.TimeStampUtc > TimeSpan.FromHours(1))
            {
                throw new LateEventException("The event is more than an hour old.");
            }
            if (eventDto.Action == "START_DO_NOT_DISTURB" && (eventTime >= TimeSpan.FromHours(11) && eventTime <= TimeSpan.FromHours(13)))
            {
                agentDto.State = DTO.AgentState.ON_LUNCH;
            }
            else if (eventDto.Action == "CALL_STARTED")
            {
                agentDto.State = DTO.AgentState.ON_CALL;
            }

            agentDto.Skills = eventDto.QueueIds;

            await _agentsRepository.UpdateAgent(agentDto);

            return agentDto;
        }
    }
}
