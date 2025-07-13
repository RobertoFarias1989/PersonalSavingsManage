using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;
using PersonalSavingsManage.API.ExtensionMethods;
using PersonalSavingsManage.Application;
using PersonalSavingsManage.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Services.AddApiVersioning(o =>
{
    o.DefaultApiVersion = new ApiVersion(1);
    o.ReportApiVersions = true;
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.ApiVersionReader = new UrlSegmentApiVersionReader(); // api/v1/transactions
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "PersonalSavingsManage",
        Description = "An api for manage your personal financial goals",
        Contact = new OpenApiContact
        {
            Name = "Roberto Farias",
            Email = "robertosf1989@gmail.com",
            Url = new Uri("https://github.com/RobertoFarias1989")
        }
    });

    var xmlFilenma = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilenma));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //app.UseSwaggerUI(o =>
    //{
    //    foreach (var desciption in app.Services.GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions)
    //    {
    //        o.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json"),
    //            description.GroupName.To
    //    }
    //});
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
