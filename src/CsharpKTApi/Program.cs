using CsharpKTApi.Mappers;
using CsharpKTApi.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Example on how to "see" what each section contains, helpful for debug!
//var teamSettingsSection = builder.Configuration.GetSection("TeamTypology");
//var teamSettingsSection2 = builder.Configuration.GetSection("TeamTypology:Default");

//Example on how to setup configuration "manually" or how to have configuration available during services setup
//var teamSettings = new TeamTypologySettings();
//builder.Configuration.Bind("TeamTypology", teamSettings);
//builder.Services.AddSingleton(teamSettings);

// Example on how to setup configuration using the IOptions/IOptionsSnapshot interface
// You can read more about it here - https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-8.0
builder.Services.Configure<TeamTypologySettings>(builder.Configuration.GetSection("TeamTypology"));

builder.Services.AddScoped<IDeveloperMapper, DeveloperMapper>();

var app = builder.Build();

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
