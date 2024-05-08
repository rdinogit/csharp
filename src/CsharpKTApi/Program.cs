using CsharpKTApi;
using CsharpKTApi.Persistence;
using CsharpKTApi.Providers;
using CsharpKTApi.Repositories;
using CsharpKTApi.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDevelopmentTeam(builder.Configuration);
builder.Services.AddKtApiVersioning();

builder.Services.Configure<JwtTokenSettings>(builder.Configuration.GetSection("JwtTokenSettings"));
builder.Services.AddScoped<IDateTimeProvider, DateTimeProvider>();
builder.Services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();

builder.Services.AddSqlite<CsharpDbContext>($"Data Source=C:\\Users\\rcber\\source\\KT\\csharp\\src\\CsharpKTApi\\Persistence\\database\\csharp.db");
builder.Services.AddScoped<IDeveloperRepository, DeveloperRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddAuthentication()
    .AddJwtBearer();

builder.Services.ConfigureOptions<ConfigureJwtBearerOptions>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Api versioning Swagger integration https://github.com/dotnet/aspnet-api-versioning/wiki/Swashbuckle-Integration
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in app.DescribeApiVersions())
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName);
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
