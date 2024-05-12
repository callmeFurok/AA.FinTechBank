using AA.FinTechBank.Application.IServices;
using AA.FinTechBank.Application.Services;
using AA.FinTechBank.Domain.IRepositories;
using AA.FinTechBank.Infrastructure.DbContextApp;
using AA.FinTechBank.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add dependency inyection
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository,ClientRepository>();   

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Connection DB
builder.Services.AddDbContext<ApplicationDbContext>(options=>
options.UseNpgsql(builder.Configuration.GetConnectionString("PostresDb")));



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // Aplica migraciones automáticamente
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
