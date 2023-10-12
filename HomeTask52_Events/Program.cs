using FileBaseContext.Context.Models.Configurations;
using HomeTask52_Events.Events;
using HomeTask52_Events.Services;
using HomeTask52_Events.Services.Interfaces;
using N52_HT1.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IDataContext, AppFileContext>(_ =>
{
    var options = new FileContextOptions<AppFileContext>
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "DataStorage")
    };

    var context = new AppFileContext(options);
    context.FetchAsync().AsTask().Wait();

    return context;
});

builder.Services.AddSingleton<IUserService, UserService>()
    .AddSingleton<IAccountService, AccountService>()
    .AddSingleton<IEmailSenderService, EmailSenderService>()
    .AddSingleton<AccountEventStore>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();