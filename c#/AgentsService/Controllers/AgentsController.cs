namespace CallCenter.AgentsService.Controllers
{
    using CallCenter.AgentsService.Domain;
    using CallCenter.AgentsService.Utils;
    using CallCenter.DTO;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("agents")]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentsDomain _agentsDomain;

        public AgentsController(IAgentsDomain agentsDomain)
        {
            _agentsDomain = agentsDomain;
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAgent(EventDto eventDto)
        {
            try
            {
                if (eventDto == null)
                    return BadRequest("A valid event must be provided.");

                if (string.IsNullOrWhiteSpace(eventDto.Action))
                    return BadRequest("An action must be provided.");

                if (eventDto.TimeStampUtc > DateTime.Now)
                    return BadRequest("Timestamp can't be later than current date / time.");

                if (string.IsNullOrEmpty(eventDto.AgentId.ToString()))
                    return BadRequest("Agent Id is invalid.");

                if (string.IsNullOrEmpty(eventDto.AgentName))
                    return BadRequest("Agent name is invalid.");

                var result = await _agentsDomain.UpdateAgent(eventDto);

                return Ok(result);
            }
            catch (LateEventException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotSupportedException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
