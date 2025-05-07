using AutoMapper;
using HealthChecks.UI.Client;
using HRBackend.Application.DTO;
using HRBackend.Application.Handlers;
using HRBackend.Application.Interface;
using HRBackend.Application.Mapping;
using HRBackend.Application.Request;
using HRBackend.Application.Services;
using HRBackend.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace HRBackend.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Подключение к БД
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySQL(connectionString));

            // Добавление контроллеров и Swagger
            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
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

            // Регистрация инфраструктуры (для работы с БД)
            builder.Services.AddInfrastructure(builder.Configuration);

            // Настройки JWT из конфигурации
            var jwtSection = builder.Configuration.GetSection("JwtSettings");
            var jwtKey = jwtSection["Secret"]!;
            var jwtIssuer = jwtSection["Issuer"];
            var jwtAudience = jwtSection["Audience"];

            // Настройка аутентификации с использованием JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

            builder.Services.AddAuthorization(); // Добавление авторизации

            // Регистрация MediatR
            builder.Services.AddScoped<IWorkingGroupService, WorkingGroupService>();
            builder.Services.AddMediatR(typeof(Program).Assembly);  // Регистрация MediatR для всех обработчиков
            builder.Services.AddAutoMapper(typeof(WorkingGroupProfile)); // Регистрируем профиль AutoMapper вручную


            builder.Services.AddScoped<IRequestHandler<LoginRequest, UserDTO>, AuthenticateUserHandler>();

            // Регистрация сервиса UserService
            builder.Services.AddScoped<IUserService, UserService>();


            builder.Services.AddHttpContextAccessor();

            // Регистрация JwtService для генерации токенов
            builder.Services.AddScoped<JwtService>();

            // Регистрация AutoMapper
            builder.Services.AddAutoMapper(typeof(Program).Assembly); // Добавьте AutoMapper здесь



            // Health Checks и UI
            builder.Services.AddHealthChecks().AddMySql(connectionString);


            builder.Services.AddScoped<IWorkingGroupService, WorkingGroupService>();
            builder.Services.AddScoped<IRequestHandler<WorkingGroupRequest, WorkingGroupDTO>, WorkingGroupCreateHandler>();

            builder.Services.AddScoped<IRequestHandler<UpdateWorkingGroupRequest, WorkingGroupDTO>, WorkingGroupUpdateHandler>();

            builder.Services.AddScoped<IRequestHandler<DeleteWorkingGroupRequest, bool>, WorkingGroupDeleteHandler>();


            builder.Services.AddScoped<ICandidateService, CandidateService>();
            builder.Services.AddScoped<IRequestHandler<CandidateCreateRequest, CandidateDTO>, CandidateCreateHandler>();


            builder.Services.AddHealthChecksUI(options =>
            {
                options.SetEvaluationTimeInSeconds(15);
                options.MaximumHistoryEntriesPerEndpoint(60);
                options.AddHealthCheckEndpoint("HRBackend API", "/health");
            }).AddInMemoryStorage();

            var app = builder.Build();

            // Middleware
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRBackend API V1");
                    c.RoutePrefix = "swagger";  // UI будет доступен по /swagger
                });
            }

            // Аутентификация и авторизация
            app.UseAuthentication();
            //app.Use(async (context, next) =>
            //{
            //    var token = context.Request.Headers["Authorization"].ToString();
            //    Console.WriteLine($"Received token: {token}");  // Логируем токен
            //    await next.Invoke();
            //});
            app.UseAuthorization();

            // Health Check endpoints
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/health-ui"; // UI доступен по /health-ui
            });

            // Контроллеры
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
