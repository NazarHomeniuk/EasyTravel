using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using EasyTravel.Contracts.Interfaces.Helpers;
using EasyTravel.Contracts.Interfaces.Services;
using EasyTravel.Contracts.Interfaces.Services.HangFire;
using EasyTravel.Core.Config;
using EasyTravel.Core.Data;
using EasyTravel.Core.Models.Identity;
using EasyTravel.HangFire.Services;
using EasyTravel.Services.BingMaps;
using EasyTravel.Services.BlaBlaCar;
using EasyTravel.Services.Bus;
using EasyTravel.Services.Helpers;
using EasyTravel.Services.Http;
using EasyTravel.Services.Railway;
using EasyTravel.Sms.Services;
using EasyTravel.Smtp.Services;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace EasyTravel.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOptions();
            services.Configure<BlaBlaCarConfig>(Configuration.GetSection("BlaBlaCar"));
            services.Configure<RailwayConfig>(Configuration.GetSection("Railway"));
            services.Configure<BusConfig>(Configuration.GetSection("Bus"));
            services.Configure<BingMapsConfig>(Configuration.GetSection("BingMaps"));
            services.Configure<HangFireConfig>(Configuration.GetSection("HangFire"));
            services.Configure<IdentityConfig>(Configuration.GetSection("Authentication"));
            services.Configure<SmtpConfig>(Configuration.GetSection("Smtp"));
            services.Configure<SmsConfig>(Configuration.GetSection("Sms"));

            services.AddTransient<BlaBlaCarFinder>();
            services.AddTransient<RailwayFinder>();
            services.AddTransient<BusFinder>();
            services.AddTransient<SmtpService>();
            services.AddTransient<SmsService>();
            services.AddTransient<IRailwayMonitoringService, RailwayMonitoringService>();
            services.AddTransient<IBusMonitoringService, BusMonitoringService>();
            services.AddTransient<IBlaBlaCarMonitoringService, BlaBlaCarMonitoringService>();
            services.AddTransient<IDateFormatter, DateFormatter>();
            services.AddTransient<IHttpService, HttpService>();
            services.AddTransient<IMapsService, MapsService>();
            services.AddTransient<ILinkBuilder, LinkBuilder>();

            var connectionString = Configuration["ConnectionString:EasyTravel"];
            services.AddDbContext<DataContext>(opts => opts.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("EasyTravel.Core")));
            services.AddIdentity<User, IdentityRole>(opts =>
                {
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireDigit = false;
                    opts.Password.RequiredLength = 6;
                    opts.User.RequireUniqueEmail = true;
                    opts.User.AllowedUserNameCharacters += " ";
                })
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["Authentication:Issuer"],
                        ValidAudience = Configuration["Authentication:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:Key"])),
                        ClockSkew = TimeSpan.FromDays(1)
                    };
                });
            services.AddHangfire(x => x.UseSqlServerStorage(connectionString));
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
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            var supportedCultures = new[] { new CultureInfo("uk-UA") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("uk-UA")),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            app.UseMvc();
        }
    }
}
