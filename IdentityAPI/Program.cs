
using Identity.API.Configurations;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

await builder.ConfugureAsync();

var app = builder.Build();

await app.ConfigureAsync();

await app.RunAsync();