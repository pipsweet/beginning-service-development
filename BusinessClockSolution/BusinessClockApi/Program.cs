using BusinessClockApi;
using BusinessClockApi.Models;
using BusinessClockApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<BusinessClock>();
builder.Services.AddSingleton<ISystemTime, SystemTime>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/status", (BusinessClock clock) =>
{
    var fakeResponse = new ClockResponseModel
    {
        IsOpen = true,
        SupportContact = new SupportContactResponseModel
        {
            Name = "Mitch",
            Phone = "800 555-1212",
            Email = "mitch@company.com"
        }
    };
    return Results.Ok(fakeResponse);
});

app.Run();


public partial class Program { }
