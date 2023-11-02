using EduCource.API.Configuration;


var builder = WebApplication.CreateBuilder(args);
await builder.ConfigureAsync();

var app = builder.Build();
await app.ConfigureAsync();

await app.RunAsync();