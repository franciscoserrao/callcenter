using CallCenter.AgentsService.Domain;
using CallCenter.AgentsService.Repository;
using CallCenter.AgentsService.Repository.Context;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddScoped<IAgentsDomain, AgentsDomain>();
builder.Services.AddScoped<IAgentsRepository, AgentsRepository>();
builder.Services.AddScoped<DatabaseContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
