// See https://aka.ms/new-console-template for more information
using allgood;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

Console.WriteLine("All good!");

string environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT") ?? throw new Exception("NETCORE_ENVIRONMENT variable not found");
Console.WriteLine($"Environment: {environment}");

var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();
var configurationRoot = builder.Build();

Paycheck? p0 = configurationRoot.GetSection("Paycheck").Get<Paycheck>();
if (p0 == null) return;

// Let's generate a bi-weekly paycheck calendar through end of 2026
var firstDate = new DateTime(2023, 5, 18);
var nextDate = firstDate;
var cash = 0.0m;
while (nextDate < new DateTime(2026, 12, 31))
{
    cash += p0.NetAmount;
    Console.WriteLine($"{nextDate:yyyy-MM-dd dddd}:{cash:c}");
    nextDate = nextDate.AddDays(14);
}

