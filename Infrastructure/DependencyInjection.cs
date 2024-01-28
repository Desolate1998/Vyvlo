using Common.JwtTokenGenerator;
using Infrastructure.Core.Authentication;
using Infrastructure.Database.Context;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Text.Unicode;
using Domain.Common.Interfaces;
using Domain.Common.Settings;
using Domain.Repository_Interfaces;
using Infrastructure.Core.FileHandler;
using Microsoft.AspNetCore.Components.Server.Circuits;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        var fileDirectorySettings = new FileDirectorySettings();
        configuration.Bind(FileDirectorySettings.SectionName, fileDirectorySettings);
        services.Configure<FileDirectorySettings>(configuration.GetSection(FileDirectorySettings.SectionName));
        
        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials();
            });
        });
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") 
            ?? throw new InvalidDataException("ASPNETCORE_ENVIRONMENT is not set")))
        );

        services.AddAuthentication(defaultScheme:JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options=> options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
        });

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();
        services.AddScoped<IFileHandler, FileHandler>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
