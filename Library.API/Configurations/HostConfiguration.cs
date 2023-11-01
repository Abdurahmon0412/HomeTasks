namespace Library.API.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfugureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddPersistance()
            .AddLibraryInfrastructure()
            .AddDevTools()
            .AddExposers();
        return new( builder);
    }

    public static ValueTask<WebApplication> ConfugureAsync(this WebApplication application)
    {
        application
            .UseDevTools().UseExposers(); 

        return new( application);
    }
}