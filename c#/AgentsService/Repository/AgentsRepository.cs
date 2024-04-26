namespace CallCenter.AgentsService.Repository
{
    using CallCenter.AgentsService.Repository.Context;
    using CallCenter.AgentsService.Repository.Data.MongoDB;
    using CallCenter.AgentsService.Repository.Data.PostgreSQL;
    using CallCenter.DTO;
    using Microsoft.EntityFrameworkCore;
    using MongoDB.Driver;

    public class AgentsRepository : IAgentsRepository
    {
        private readonly DatabaseContext _dbContextFactory;

        public AgentsRepository(DatabaseContext dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<AgentDto> GetAgentDtoById(string id)
        {
            AgentData agentData = new AgentData();

            using (var context = _dbContextFactory.CreateDbContext())
            {
                if (context is MongoDbContext mongoDbContext)
                {
                    var mongoagentData = await mongoDbContext.AgentDataCollection.Find(a => a._id == id).FirstOrDefaultAsync();
                    agentData.state = mongoagentData.state;
                    agentData.name = mongoagentData.name;
                    agentData.skills = mongoagentData.skills;
                    agentData.id = Guid.Parse(mongoagentData.id);
                }
                else if (context is PostgreSQLDbContext postgresDbContext)
                {
                    agentData = await postgresDbContext.agentdata.FindAsync(Guid.Parse(id));
                }
            }
            return MapToAgentDto(agentData);
        }

        public async Task<AgentDto> UpdateAgent(AgentDto agentDto)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                if (context is MongoDbContext mongoDbContext)
                {
                    var filter = Builders<MongoAgentData>.Filter.Eq(a => a.id, agentDto.Id.ToString());
                    var update = Builders<MongoAgentData>.Update
                        .Set(a => a.skills, agentDto.Skills)
                        .Set(a => a.state, agentDto.State);
                    await mongoDbContext.AgentDataCollection.UpdateOneAsync(filter, update);
                }
                else if (context is PostgreSQLDbContext postgresDbContext)
                {
                    var existingAgentData = await postgresDbContext.agentdata.FindAsync(agentDto.Id);

                    existingAgentData.skills = agentDto.Skills;
                    existingAgentData.state = agentDto.State;

                    await postgresDbContext.SaveChangesAsync();
                }
            }
            return agentDto;
        }

        private AgentDto MapToAgentDto(AgentData agentData)
        {
            return agentData == null ? null : new AgentDto
            {
                Id = agentData.id,
                Name = agentData.name,
                Skills = agentData.skills,
                State = agentData.state,
            };
        }
    }
}
