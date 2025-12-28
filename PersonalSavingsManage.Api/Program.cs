using Microsoft.Extensions.Configuration;
using PersonalSavingsManage.Application;
using PersonalSavingsManage.Infrastructure;
using PersonalSavingsManage.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var jwtOptions = builder.Services.AddOptions<JwtOptions>()
       .Bind(builder.Configuration.GetSection("Jwt"))
       .ValidateOnStart();

builder.Services.AddAplication();
builder.Services.AddInfrastructure(builder.Configuration, (Microsoft.Extensions.Options.IOptions<JwtOptions>)jwtOptions);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
