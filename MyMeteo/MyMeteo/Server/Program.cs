using Microsoft.AspNetCore.ResponseCompression;
using MyMeteo.Shared;
using SoloX.TableModel.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add TableModelServer services
builder.Services.AddTableModelServer(config =>
{
    // We are going to use a In Memory table.
    config.UseMemoryTableData<WeatherForecast>(
        memoryTableConfig =>
        {
            // Add the data to the memory table.
            memoryTableConfig.AddData(GetWeatherForecastData());
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();


/// <summary>
/// Create a random WeatherForecast collection.
/// </summary>
IEnumerable<WeatherForecast> GetWeatherForecastData()
{
    var Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // Set up some random WeatherForcast data.
    return Enumerable.Range(1, 1000)
        .Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
}