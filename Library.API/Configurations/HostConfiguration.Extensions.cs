using Library.Domain.Entities;
using Library.Infrastructure.Foundations;
using Library.Persistance.DataContexts;
using LIbrary.Application.Common;
using LIbrary.Application.Foundations;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Configurations
{
    public static partial class HostConfiguration
    {
        public static WebApplicationBuilder AddLibraryInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IEntityBaseService<Author>, AuthorService>();
            builder.Services.AddScoped<IEntityBaseService<Book>, BookService>();

            return builder;
        }
        public static WebApplicationBuilder AddPersistance(this WebApplicationBuilder builder)
        {
            var databaseConnectionSettings = new DataBaseConnectionSettings();
            builder.Configuration.GetSection(nameof(DataBaseConnectionSettings)).Bind(databaseConnectionSettings);

            builder.Services.AddDbContext<AppDbContext> (options => options
            .UseNpgsql(databaseConnectionSettings.DbConnectionString));

            return builder;
        }

        public static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();

            return builder;
        }

        public static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            return builder;
        }

        public static WebApplication UseDevTools(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }

        public static WebApplication UseExposers(this WebApplication app)
        {
            app.MapControllers();

            return app;
        }
    }
}
