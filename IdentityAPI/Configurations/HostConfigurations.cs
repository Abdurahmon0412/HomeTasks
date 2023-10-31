namespace Identity.API.Configurations;

public static partial class HostConfigurations
{
    public static ValueTask<WebApplicationBuilder> ConfugureAsync(this WebApplicationBuilder builder)
    {
        builder
             .AddPersistance()
             .AddIdentityInfrastructure()
             .AddNotificationInfrastructure()
             .AddExposers()
             .AddDevTools();

        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseIdentityInfrastructure()
            .UseExposers()
            .UseDevTools();

        return new(app);
    }
}