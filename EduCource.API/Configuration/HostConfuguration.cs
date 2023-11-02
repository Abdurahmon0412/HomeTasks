namespace EduCource.API.Configuration
{
    public static partial class HostConfuguration
    {
        public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
        {
            builder
                .AddPersistence()
                .AddIdentityInfrastructure()
                .AddDevTools()
                .AddExposers();

            return new(builder);
        }

        public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
        {
            app
                .UseDevTools()
                .UseExposers();

            return new(app);
        }
    }
}