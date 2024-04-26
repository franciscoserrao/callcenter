namespace CallCenter.AgentsService.Repository.Context
{
    using Microsoft.EntityFrameworkCore;

    public class DatabaseContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbContext CreateDbContext()
        {
            var provider = _configuration.GetConnectionString("DatabaseProvider");

            if (provider == "MongoDB")
            {
                return new MongoDbContext(_configuration);
            }
            else if (provider == "PostgreSQL")
            {
                var connectionString = _configuration.GetConnectionString("PostgreSQLConnection");
                var optionsBuilder = new DbContextOptionsBuilder<PostgreSQLDbContext>();
                optionsBuilder.UseNpgsql(connectionString);
                return new PostgreSQLDbContext(_configuration);
            }
            else
            {
                throw new NotSupportedException("Database specified is not supported.");
            }
        }
    }
}
