using EduCource.Application.Foundations;
using EduCource.Domain.Entities;
using EduCource.Infrastructure.Foundations;
using EduCource.Persistance.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace EduCource.API.Configuration;

public static partial class HostConfuguration
{
    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEntityBaseService<User>, UserService>()
                        .AddScoped<IEntityBaseService<Role>, RoleService>()
                        .AddScoped<IEntityBaseService<Course>, CourseService>()
                        .AddScoped<IEntityBaseService<CourseStudent>, CourseStudentService>()
                        .AddScoped<IEntityBaseService<UserSettings>, UserSettingsService>()
                        .AddScoped<IEntityBaseService<Location>, LocationService>();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}
