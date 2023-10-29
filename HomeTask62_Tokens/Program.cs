using HomeTask62_Tokens.Services;

namespace HomeTask62_Tokens;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddScoped<LoginService>();
        builder.Services.AddTransient<TokenGeneratorService>();
        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapControllers();

        app.Run();
    }
}