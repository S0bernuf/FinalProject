using System.Text;
using FinalProject.BusinessLogic.MappingProfiles;
using FinalProject.BusinessLogic.Services;
using FinalProject.BusinessLogic.Services.Interfaces;
using FinalProject.Database;
using FinalProject.Database.Repositories;
using FinalProject.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace FinalProject.Api
{
    
    /*
     * 1. builder.Services.AddBusinessLogicServices(); this will inject all services from BusinessLayer Extensions
     * 2. These:             builder.Services.AddScoped<IUserService, UserService>();
                             builder.Services.AddScoped<IJwtService, JwtService>();
        can be removed, and do not forget to add in BusinessLogic Extensions:
                            builder.Services.AddScoped<IPersonService, PersonService>();
        3. You can move this: builder.Services.AddAutoMapper(typeof(MappingProfile)); in BusinessLogic Extensions as well
        4. after refactoring remove not used using's
        5. I might be wrong have not tested yet, but i think you should add this in Program.cs:
            builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
        options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    });
    
        6. Delete FinalProjectApplication.http file if not used
        7. Delete Photos folder if not used as well
        8. Do not push filled appsettings.json with all settings, leave them blank
     */

    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //For Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "FinalProject API",
                    Description = "Product WebAPI"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            new List<string>()
                        }
                });
            });

            //For Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            //Add services to the container.
            builder.Services.AddDbContext<FinalProjectDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddControllers();

            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinalProject API v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }
}

