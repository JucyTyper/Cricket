using Microsoft.EntityFrameworkCore;
using Cricket.Data;
using Cricket.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CricketDatabase>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CricketDatabaseConnectionString")));
builder.Services.AddScoped<IPlayerServices, PlayerService>();
builder.Services.AddScoped<IMatchService, MatchService>();
var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
