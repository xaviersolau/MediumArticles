using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyMeteo.Client;
using MyMeteo.Shared;
using SoloX.TableModel;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add TableModel services
builder.Services.AddTableModel(config =>
{
    // We are going to use the remote table from the server.
    config.UseRemoteTableData<WeatherForecast>(
        tableDataConfig =>
        {
            // Create a new HttpClient with the right controller base address.
            tableDataConfig.HttpClient = new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/TableData/")
            };
        });
});

await builder.Build().RunAsync();
