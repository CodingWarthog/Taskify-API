using System;
using System.Text;
using AutoMapper;
using HakatonApi.Helpers;
using HakatonApi.Models;
using HakatonApi.Repositories;
using HakatonApi.Repositories.GlobalWaitingTaskRepositories;
using HakatonApi.Repositories.GPSRepositories;
using HakatonApi.Repositories.MapRepository;
using HakatonApi.Repositories.TaskTagRepositories;
using HakatonApi.Repositories.WaitingTaskLocationRepository;
using HakatonApi.Repositories.WaitingTaskRepository;
using HakatonApi.Services;
using HakatonApi.Services.GlobalTaskServices;
using HakatonApi.Services.GPSServices;
using HakatonApi.Services.TaskTagService;
using HakatonApi.Services.TaskTagServices;
using HakatonApi.Services.WaitingTaskServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace HakatonApi
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
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddMvc().AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<HackathonWAWContext>(x => x.UseSqlServer("Server=tcp:hackathondbserverv1.database.windows.net,1433;Initial Catalog=HackathonWAW;Persist Security Info=False;User ID=HackathonAdmin;Password=!@#Hackathon123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddCors();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("secret")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            
            //services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IGPSService, GPSService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IMapService, MapService>();
            services.AddScoped<ITaskTagService, TaskTagService>();

            //repositories
            services.AddScoped<IGPSRepository, GPSRepository>();
            services.AddTransient<IWaitingTaskLocationRepository, WaitingTaskLocationRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddScoped<IMapRepository, MapRepository>();

            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddScoped<ITaskTagService, TaskTagService>();
            services.AddScoped<ITaskTagRepository, TaskTagRepository>();

            services.AddScoped<IWaitingTaskService, WaitingTaskService>();
            services.AddScoped<IWaitingTaskRepository, WaitingTaskRepository>();

            services.AddScoped<IGlobalTaskRepository, GlobalTaskRepository>();
            services.AddScoped<IGlobalTaskService, GlobalTaskService>();
            

            services.AddTransient<IUserGeter, UserGeter>();
            services.AddHttpContextAccessor();

            services.AddAutoMapper();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ReminderApp",
                    Description = "Hackathon app",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mateusz Stroba",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Jakiekolwiek użycie zabronione",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
