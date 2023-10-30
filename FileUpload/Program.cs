using FileBaseContext.Context.Models.Configurations;
using FileUpload.Models.Settings;
using FileUpload.Presentation;
using FileUpload.Services.Foundations;
using FileUpload.Services.Identity;
using FileUpload.Services.Processing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(cw =>
{
    cw.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JwtToken_Auth_API",
        Version = "v1"
    });
    cw.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT Token",
    });
    cw.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRouting(options => options.LowercaseQueryStrings = true);
builder.Services.AddControllers();

builder.Services.AddScoped<IDataContext, AppFileContext>(_ =>
{
    var contextOptions = new FileContextOptions<AppFileContext>
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "DataStorage")
    };

    var context = new AppFileContext(contextOptions);
    context.FetchAsync().AsTask().Wait();

    return context;
});

builder.Services.AddTransient<TokenGeneratorService>();
builder.Services.AddTransient<PasswordHashService>();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<FileService>();
builder.Services.AddScoped<StorageFileService>();
builder.Services.AddScoped<FileProcessingService>();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof (JwtSettings)));
builder.Services.Configure<FileSettings> (builder.Configuration.GetSection(nameof(FileSettings)));

var jwtSettings = new JwtSettings();
builder.Configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = jwtSettings.ValidateIssuer,
            ValidIssuer = jwtSettings.ValidIssuer,
            ValidateAudience = jwtSettings.ValidateAudience,
            ValidAudience = jwtSettings.ValidAudience,
            ValidateLifetime = jwtSettings.ValidateLifeTime,
            ValidateIssuerSigningKey = jwtSettings.ValidateSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
        };
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();