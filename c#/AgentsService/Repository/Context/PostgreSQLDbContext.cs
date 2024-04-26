namespace CallCenter.AgentsService.Repository.Context
{
    using CallCenter.AgentsService.Repository.Data.PostgreSQL;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class PostgreSQLDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<AgentData> agentdata { get; set; }

        public PostgreSQLDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection"));
        }
    }
}