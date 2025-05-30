using AutoMapper;
using HealthChecks.UI.Client;
using HRBackend.Application.Interface;
using HRBackend.Application.Services;
using HRBackend.Domain.Repositories;
using HRBackend.Persistence;
using HRBackend.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();

ConfigureServices(
services: builder.Services,
configuration: builder.Configuration);

builder.Host.UseDefaultServiceProvider((context, options) =>
{
    options.ValidateOnBuild = context.HostingEnvironment.IsDevelopment();
    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
});

var app = builder.Build();

Configure(
app: app,
env: app.Environment);
await app.RunAsync();


void AddDbContext(IServiceCollection services, IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");

    services.AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(connectionString,
        builder =>
        {
            var assembly = typeof(AppDbContext).Assembly.FullName;
            builder.MigrationsAssembly(assembly);
        });

        options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
    });
}
void AddRepositories(IServiceCollection services)//репозитории scoped потому что должны быть созданы на каждый запрос свои
{
    services.AddScoped<IUserReposiotry, UserRepository>();
    services.AddScoped<ICandidateRepository, CandidateRepository>();
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddHttpContextAccessor();
}
void AddHttpClients(IServiceCollection services)
{
    services.AddHttpContextAccessor();
}
void AddAuth(IServiceCollection services, IConfiguration configuration)
{
    // Настройки JWT из конфигурации
    var jwtSection = configuration.GetSection("JwtSettings");
    var jwtKey = jwtSection["Secret"]!;
    var jwtIssuer = jwtSection["Issuer"];
    var jwtAudience = jwtSection["Audience"];

    // Настройка аутентификации с использованием JWT
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtIssuer,
                ValidAudience = jwtAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                RoleClaimType = ClaimTypes.Role
            };
        });

    services.AddAuthorization(); // Добавление авторизации
}
void AddServices(IServiceCollection services)//сервисы scoped потому что должны быть созданы на каждый запрос свои
{
    //services.AddScoped<CandidateService>();
    services.AddScoped<JwtService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<ICandidateService, CandidateService>();
}
void AddHealthChecks(IServiceCollection services)
{
    services.AddHealthChecks();
    services.AddHealthChecksUI(options =>
    {
        options.SetEvaluationTimeInSeconds(15);
        options.MaximumHistoryEntriesPerEndpoint(60);
        options.AddHealthCheckEndpoint("HRBackend API", "/health");
    }).AddInMemoryStorage();
}
void AddSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(c =>
    {
        // Настройка JWT для Swagger
        c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Description = "Введите токен JWT",
            Name = "Authorization",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
    }); // Добавление Swagger
}
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    AddDbContext(services, configuration);
    AddRepositories(services);
    AddHttpClients(services);
    AddServices(services);
    AddHealthChecks(services);
    AddAuth(services, configuration);
    AddSwagger(services);

    services.AddAutoMapper(typeof(Program).Assembly);
    services.AddControllersWithViews();
    services.AddEndpointsApiExplorer();
}
void Configure(WebApplication app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRBackend API V1");
            c.RoutePrefix = "swagger";  // UI будет доступен по /swagger
        });
    }
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseHealthChecks("/health", new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

    app.UseHealthChecksUI(options =>
    {
        options.UIPath = "/health-ui"; // UI доступен по /health-ui
    });

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

}
