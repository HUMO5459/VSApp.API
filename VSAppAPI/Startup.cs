using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using VSApp.API.Filters;
using VSApp.Business.Interfaces;
using VSApp.Business.Interfaces.Base;
using VSApp.Business.Mappers;
using VSApp.Business.Repositories;
using VSApp.Business.Repositories.Base;
using VSApp.Business.Services;
using VSApp.Business.Settings;
using VSApp.Core.Repositories;
using VSApp.Core.Repositories.Base;
using VSApp.Infrastructure.Data;
using VSApp.Infrastructure.Repositories;
using VSApp.Infrastructure.Repositories.Base;

namespace VSAppAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TokenSetting>(Configuration.GetSection(nameof(TokenSetting)));

            ConfigureVSAppServices(services, Configuration);
            ConfigureJwtAuthentication(services, Configuration);


            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
            const string domen = "http://www.vsapp.uz";
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                {
                    Version = "v1",
                    Title = "VSApp API",
                    Description = "API documentation for integrations",
                    TermsOfService = new Uri($"{domen}/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Vision Swipe",
                        Email = "visionswipe@gmail.com",
                        Url = new Uri($"{domen}"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "using api-licence under VisionSwipe licences",
                        Url = new Uri($"{domen}/license"),
                    }
                });

                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "VSApp API 2",
                    Description = "API documentation for integrations 2",
                    TermsOfService = new Uri($"{domen}/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Vision Swipe",
                        Email = "visionswipe@gmail.com",
                        Url = new Uri($"{domen}"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "using api-licence under VisionSwipe licences",
                        Url = new Uri($"{domen}/license"),
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization Bearer",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

                c.OperationFilter<RemoveVersionFromParameter>();
                c.DocumentFilter<ReplaceVersionWithExactValueInPath>();
                c.DocInclusionPredicate((_, api) => !string.IsNullOrWhiteSpace(api.GroupName));
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddHttpContextAccessor();

        }
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDataContext appDataContext)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VSAppAPI v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "VSAppAPI v2");
                c.InjectStylesheet("/css/swagger-style.css");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            appDataContext.Database.Migrate();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCors(option => option
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public static void ConfigureVSAppServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register DataContext
            ConfigureDatabases(services, configuration);

            // Infrastructure Layer
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped(typeof(ILogicRepository<,>), typeof(LogicRepository<,>));
            services.AddScoped<IUserLogicRepository, UserLogicRepository>();

            // Business Layer
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IEnteringService, EnteringService>();
            services.AddScoped<IExitingService, ExitingService>();
            services.AddScoped<IServerService, ServerService>();
            services.AddScoped<ICameraService, CameraService>();

            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(IEMapper));

            services.AddRouting(options => options.LowercaseUrls = true);
        }
        public static void ConfigureJwtAuthentication(IServiceCollection services, IConfiguration Configuration)
        {
            var key = Encoding.ASCII.GetBytes(Configuration["TokenSetting:Secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireSignedTokens = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
                x.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        context.Response.StatusCode = 401;
                        //context.Response.Body = new ApiResponse(401, "");
                        context.Response.Headers.Append("my-custom-header", "custom-value");
                        await context.Response.WriteAsync("You are not authorized");
                    }
                };
            });
        }
        public static void ConfigureDatabases(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDataContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("VSAppConnectionString"))
                    .EnableSensitiveDataLogging();
            });
        }

    }
}
