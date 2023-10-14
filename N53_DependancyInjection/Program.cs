using FileBaseContext.Context.Models.Configurations;
using HomeTask52_Events.Events;
using HometaskN48_API.Services.Interfaces;
using N52_HT1.DataAccess;
using N53_DependancyInjection.Events;
using N53_DependancyInjection.Services.FoundationServices;
using N53_DependancyInjection.Services.Interfaces;
using N53_DependancyInjection.Services.ManagementServices;
using N53_DependancyInjection.Services.NotificationServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
    .AddSingleton<OrderEventStore>()
    .AddSingleton<BonusEventStore>()
    .AddSingleton<UserBonusService>()
    .AddSingleton<UserPromotionService>()
    .AddSingleton<IBonusService, BonusService>()
    .AddSingleton<IOrderService, OrderService>()
    .AddSingleton<INotificationService, EmailSenderService>()
    .AddSingleton<INotificationService, SmsSenderService>()
    .AddSingleton<INotificationService, TelegramSenderService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var test = app.Services.GetRequiredService<UserPromotionService>();
var testB = app.Services.GetRequiredService<UserBonusService>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
