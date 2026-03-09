using DoorBell.Application.DTOs.DeviceDTOs;
using DoorBell.Application.Hubs;
using DoorBell.Application.Interfaces;
using DoorBell.Application.Mapping;
using DoorBell.Application.Services;
using DoorBell.Application.Usecases.UserUsecase;
using DoorBell.Domain.Entities;
using DoorBell.Infrastructure.Persistent;
using DoorBell.Infrastructure.Respositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddScoped<JWTService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];

            var path = context.HttpContext.Request.Path;

            if (!string.IsNullOrEmpty(accessToken) &&
                path.StartsWithSegments("/doorbellHub"))
            {
                context.Token = accessToken;
            }

            return Task.CompletedTask;
        }
    };
});

// Add scoped services for application and infrastructure layers
builder.Services.AddScoped<IUser, UserRespository>();
builder.Services.AddScoped<DoorBell.Application.Usecases.UserUsecase.GetAllUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.UserUsecase.GetUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.UserUsecase.CreateUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.UserUsecase.UpdateUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.UserUsecase.DeleteUsecase>();
builder.Services.AddScoped<GetByMailUsecase>();

builder.Services.AddScoped<IDevice, DeviceRespository>();
builder.Services.AddScoped<DoorBell.Application.Usecases.DeviceUsecase.GetAllUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.DeviceUsecase.GetUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.DeviceUsecase.CreateUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.DeviceUsecase.UpdateUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.DeviceUsecase.DeleteUsecase>();

builder.Services.AddScoped<IDoorBellEvent, DoorBellEventRepository>();
builder.Services.AddScoped<DoorBell.Application.Usecases.DoorBellEventUsecase.GetAllUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.DoorBellEventUsecase.GetUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.DoorBellEventUsecase.CreateUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.DoorBellEventUsecase.UpdateUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.DoorBellEventUsecase.DeleteUsecase>();

builder.Services.AddScoped<ICallSession, CallSessionRespository>();
builder.Services.AddScoped<DoorBell.Application.Usecases.CallSessionUsecase.GetAllUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.CallSessionUsecase.GetUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.CallSessionUsecase.CreateUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.CallSessionUsecase.UpdateUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.CallSessionUsecase.DeleteUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.CallSessionUsecase.AcceptUsecase>();
builder.Services.AddScoped<DoorBell.Application.Usecases.CallSessionUsecase.RejectedUsecase>();

// AutoMapper configuration
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);
builder.Services.AddAutoMapper(typeof(DeviceProfile).Assembly);
builder.Services.AddAutoMapper(typeof(DoorBellEventProfile).Assembly);
builder.Services.AddAutoMapper(typeof(CallSessionProfile).Assembly);

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

// Configure Entity Framework Core with PostgreSQL
builder.Services.AddDbContext<DoorBellDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<DoorBellHub>("/doorbellHub");

app.Run();
