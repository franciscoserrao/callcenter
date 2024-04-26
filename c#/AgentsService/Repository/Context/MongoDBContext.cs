namespace CallCenter.AgentsService.Repository.Context
{
    using CallCenter.AgentsService.Repository.Data.MongoDB;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Driver;

    public class MongoDbContext : DbContext
    {
        private readonly IMongoCollection<MongoAgentData> _agentDataCollection;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDBConnection"));
            var database = client.GetDatabase(configuration.GetConnectionString("MongoDBName"));

            _agentDataCollection = database.GetCollection<MongoAgentData>("agentdata");
        }

        public IMongoCollection<MongoAgentData> AgentDataCollection => _agentDataCollection;
    }
}