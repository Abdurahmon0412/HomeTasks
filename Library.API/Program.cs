using Library.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

await builder.ConfugureAsync();

var app = builder.Build();

await app.ConfugureAsync();

await app.RunAsync();