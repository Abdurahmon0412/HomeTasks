using FileExplorer.Appllication.FileStorage.Brokers;
using FileExplorer.Infrastructure.FileStorage.Brokers;
using FileExplorer.Infrastructure.FileStorage.Services;
using System.Reflection;
using Training.FileExplorer.Application.FileStorage.Services;


namespace Training.FileExplorer.Api.Configurations;

public static partial class HostConfiguration
{
    #region Builder configurations

    private static WebApplicationBuilder AddMapping(this WebApplicationBuilder builder)
    {
        var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();

        assemblies.Add(Assembly.GetExecutingAssembly());

        builder.Services.AddAutoMapper(assemblies);

        return builder;
    }

    private static WebApplicationBuilder AddBrokers(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddSingleton<IDriveBroker, DriveBroker>()
            .AddSingleton<IDirectoryBroker, DirectoryBroker>()
            .AddSingleton<IFileBroker, FileBroker>();

        return builder;
    }

    private static WebApplicationBuilder AddFileStorageInfrastructure(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddSingleton<IDriveService, DriveService>()
            .AddSingleton<IDirectoryService, DirectoryService>()
            .AddSingleton<IFileService, FileService>();

        builder
            .Services
            // .AddSingleton<IDriveProcessingService, DriveProcessingService>()
            .AddSingleton<IDirectoryProcessingService, DirectoryProcessingService>();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

        return builder;
    }

    private static WebApplicationBuilder AddRestExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers().AddNewtonsoftJson();
        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        return builder;
    }

    private static WebApplicationBuilder AddCustomCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", policyBuilder => { policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
        });

        return builder;
    }

    #endregion

    #region Application configurations

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger().UseSwaggerUI();

        return app;
    }

    private static WebApplication UseCustomCors(this WebApplication app)
    {
        app.UseCors("CorsPolicy");

        return app;
    }

    private static WebApplication MapRoutes(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    private static WebApplication UseFileStorage(this WebApplication app)
    {
        app.UseStaticFiles();

        return app;
    }

    #endregion
}